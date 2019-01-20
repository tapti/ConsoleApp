using System;
using System.Collections.Generic;
using System.Text;

namespace MasterMindGame
{
    public class Program
    {

        static void Main()
        {
            Program Mastermindgame = new Program();
            Mastermindgame.StartGame();
        }

        int Attempts = 10;
        public class Result
        {
            public int Index { get; set; }
            public bool Flag { get; set; }
        }

        public StringBuilder GenerateRandomNumber()
        {
            Random random = new Random();
            StringBuilder numbertoAppend = new StringBuilder(8);
            int lengthoftheNumber = 4;

            for (int i = 0; i < lengthoftheNumber; i++)
            {
                numbertoAppend.Append(random.Next(1, 6));
            }

            return numbertoAppend;
        }

        public List<Result> GetResult(StringBuilder randomNumberGeneration, StringBuilder InputoftheUser, out int Count2)
        {
            List<Result> results = new List<Result>(4);
            Count2 = 0;
            for (int index = 0; index < randomNumberGeneration.Length; index++)
            {
                Result result = new Result();
                result.Index = index;
                bool flag = randomNumberGeneration[index] == InputoftheUser[index];
                if (flag)
                {
                    Count2++;
                }
                result.Flag = flag;
                results.Add(result);
            }

            return results;
        }

       
        void StartGame()
        {
            // Number of attempts should be declared

            Console.WriteLine("\nWelcome to my version of MasterMind.");
            Console.WriteLine("\nDigits are only in between 1111 to 6666.");
            Console.WriteLine(string.Format("\nYou have {0} attempts to win the game.", Attempts));

            // Random Number Generation
            var randomNumber = GenerateRandomNumber();
            var ShowtheInputCorrect = new StringBuilder("AAAA");
            for (int i = 1; i <= Attempts; i++)
            {
                // Asking user to put digit between 1111 and 6666
                var UserSelection = new StringBuilder(GetUserInput(i, ShowtheInputCorrect));

                // Result Generation from those digits 
                int Count1 = 0;
                List<Result> ResultGen = GetResult(randomNumber, UserSelection, out Count1);
                if (Count1 > 0)
                {
                    foreach (var result in ResultGen)
                    {
                        if (result.Flag)
                        {
                            int index = result.Index;
                            ShowtheInputCorrect[index] = randomNumber[index];
                            if ((ShowtheInputCorrect[index]) == randomNumber[index])
                            {
                                Console.WriteLine("++++");
                            }
                            else
                            {
                                Console.WriteLine("----");
                            }
                        }
                    }
                }


                // check the flag count and display appropriate message
                if (Count1 == 4)
                {
                    Console.WriteLine("Your Input:{0}, Random Number:{1}", UserSelection, randomNumber);
              
                    break;
                }
                else if (i == Attempts)
                {
                   
                    Console.WriteLine("Random Number is {0}", randomNumber);
                }
                else 
                {
                    //
                    Console.WriteLine( string.Format("Input you guessed which are/is correct: {0}",  ShowtheInputCorrect));
                }
            }

            Console.ReadLine();
        }

        

        public string GetUserInput(int attempt, StringBuilder correctInputTillNow)
        {
            int NumbertobeInput;

            if (attempt == 1)
            {
             Console.WriteLine(string.Format("\n Number of Attempts remaining: {0}",Attempts - (attempt)));
            }
            else
            {
                Console.WriteLine(string.Format("\nTry guessing.Guess x: {0}, Remaining attempts: {1}", correctInputTillNow,Attempts - (attempt)));
            }
            if (
                int.TryParse(Console.ReadLine(), out NumbertobeInput)
                && NumbertobeInput.ToString().Length == 4
            )
            {
                return NumbertobeInput.ToString();
            }
            else
            {
                Console.WriteLine("Please enter a valid input.");
                return "aaaa";
            }
        }

        
    }
}