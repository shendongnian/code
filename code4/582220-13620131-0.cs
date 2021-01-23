    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace WordGame
    {
        class Game
        {
            static void Main(string[] args)
            {
                Game g = new Game();
                bool gameOver = false;
    
                while (!gameOver)
                {
                    Console.WriteLine("Enter a guess (or type 'exit' to exit):");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "exit")
                        break;
    
                    if (g.CheckWord(answer))
                    {
                        Console.WriteLine("You win!");
                        while (true)
                        {
                            Console.WriteLine("Play Again (y/n)?");
                            answer = Console.ReadLine().ToLower();
                            if (answer == "n")
                            {
                                gameOver = true;
                                break;
                            }
                            else if (answer == "y")
                            {
                                g.ChooseRandomWord();
                                break;
                            }
                        }
                    }
                }
            }
    
            public string CorrectWord;
    
            public string[] Wordarray = new string[] { "radar", "andar", "raggar", "rapar", "raser", "rastar", "rikas" };
            private Random ran = new Random();
    
            public Game()
            {
                ChooseRandomWord();
            }
    
            public void ChooseRandomWord()
            {
                CorrectWord = Wordarray[(ran.Next(0, Wordarray.Length - 1))];
            }
    
            public bool CheckWord(string guess)
            {
                if (guess.Trim() == CorrectWord)
                {
                    return true;
                }
    
                string guessLower = guess.Trim().ToLower();
                string correctLower = CorrectWord.ToLower();
    
                for (int i = 0; i < correctLower.Length; i++)
                {
                    if (guessLower[i] == correctLower[i])
                        Console.Write(guess[i]);
                    else
                        Console.Write("#");
                }
                Console.WriteLine();
    
                return false;
            }
    
        }
    }
