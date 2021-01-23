    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    class Hangman
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Title = "C# Hangman";
            Console.WriteLine("Welcome To C# Hangman!");
     
            //MENU
    
            char MenuChoice;       
    
            Console.Write("\n\t1) Add words");
            Console.Write("\n\t2) Show list of words");
            Console.Write("\n\t3) Play");
            Console.Write("\n\t4) Quit\n\n");
    
            Console.Write("\n\tChoose 1-4: ");        //Choose meny item
            MenuChoice = Convert.ToChar(Console.ReadLine());
            WordList showing = new WordList();
                switch (MenuChoice)
                {
                    case '1':
                        var input = Console.ReadLine();
                        showing.AddWord(input);
                        break;
                    case '2':
                        
                        showing.ListOfWords();
                        Console.Write("\n\tList of words\n\n");
    
    
                        break;
    
    
                    case '3':   //Running game
    
                        int guesses;
                        Console.Write("\n\tHow many faults can you have: ");
                        guesses = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\n\tAwesome, let´s play!\n");
    
    
                        String input;
                        bool wrong;
                        int NumberOfTries = 0;
    
    
                        do
                        {
                            Console.WriteLine("\n\n\tWrong guesses: " + NumberOfTries + " / " + guesses + "\n");
                            Console.WriteLine("\n\tGuessed letters:\n");
                            Console.WriteLine("\n\tWord:\n");
                            Console.Write("\n\n\tGuess letter: ");
                            input = Console.ReadLine();
                            Console.Write("\n\n\t ");
    
                            wrong = !input.Equals("t") &&
                                  !input.Equals("e") &&
                                  !input.Equals("s") &&
                                  !input.Equals("t"); 
                            if (wrong)
                            {
                                NumberOfTries++;
                                Console.WriteLine("\n\tWrong letter " + "Try again!");
                            }
                            if (wrong && (NumberOfTries > guesses - 1))
                            {
                                Console.WriteLine("\n\tYou have failed " + guesses + ". End of game!\n");
                                break;
                            }
    
                        } while (wrong);
                        if (!wrong)
                            Console.WriteLine("\n\tWhohoo!");
    
                        break;
    
                    case '4':
    
                        Console.WriteLine("\n\tEnd game?\n\n");
                        break;
                }
            
        }
    
    }
