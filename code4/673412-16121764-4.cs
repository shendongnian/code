    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    public class Hangman
    {
        /* 
         * Some notes on your code:
         *   use naming convention for methods and fields, i.e. methods names start with a capital letter
         *   use modifiers for methods, i.e private, public, protected in your method declarations
         *   make variables private if you use them on several methods
         *   and finally: read a book on c#
         *   
         */
    
        private static WordList words;
        private static Random randomGen = new Random();
    
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Title = "C# Hangman";
            Console.WriteLine("Welcome To C# Hangman!");
            initializeWordList();
    
            //MENU
            int MenuChoice = 0;
            while (MenuChoice != 4)
            {
    
                Console.Write("\n\t1) Add words");
                Console.Write("\n\t2) Show list of words");
                Console.Write("\n\t3) Play");
                Console.Write("\n\t4) Quit\n\n");
    
                Console.Write("\n\tChoose 1-4: ");        //Choose meny item
    
                MenuChoice = Convert.ToInt32(Console.ReadLine());
                switch (MenuChoice)
                {
                    case 1:
                        Console.Write("\n\tAdd a word\n\n");
                        var insert = Console.ReadLine();
                        words.Add(insert);
                        Console.Write("\n\tList of words\n\n");
                        foreach (string w in words) // Display for verification
                            Console.WriteLine(w);
                        break;
                    case 2:
                        Console.Write("\n\tList of words\n\n");
                        foreach (string w in words) // Display for verification
                            Console.WriteLine(w);
                        break;
    
    
                    case 3:   //Running game
    
                        int numGuessesInt = -1;
    
                        while (numGuessesInt == -1)
                        {
                            /* Sets the number of guesses the user has to guess the word*/
                            pickNumGuesses(ref numGuessesInt);
                        }
    
                        /* Randomly picks a word*/
                        string word = PickWord();
    
    
                        /* Creates a list of characters that will show */
                        List<char> guessedLetters = new List<char>();
                        bool solved = false;
                        while (solved == false)
                        {
                            /* Displaying a string to the user based on the user's correct guesses.
                             * If nothing is correct string will return "_ _ _ " */
                            string wordToDisplay = displayWord(guessedLetters, word);
                            /* If the string returned contains the "_" character, all the
                            * correct letters have not been guessed, so checking if user
                            * has lost, by checking if numGuessesLeft is less than 1.*/
                            if (!wordToDisplay.Contains("_"))
                            {
                                solved = true;
                                Console.WriteLine("You Win!  The word was " + word);
                                /* Check if the user wants to play again.  If they do,
                                * then solved is set to true, will end the loop,
                                * otherwise, checkIfPlayAgain will close the program.*/
                                checkIfPlayAgain();
                            }
                            else if (numGuessesInt <= 0)
                            {
                                solved = true;
                                Console.WriteLine("You Lose!  The word was " + word);
                                checkIfPlayAgain();
                            }
                            else
                            {
                                /* If the user has not won or lost, call guessLetter,
                                * display the word, minus guesses by 1*/
                                guessLetter(guessedLetters, word, wordToDisplay, ref numGuessesInt);
                            }
                        }
    
                        break;
    
                    case 4:
                        Console.WriteLine("\n\tEnd game?\n\n");
                        break;
                    default:
                        Console.WriteLine("Sorry, invalid selection");
                        break;
                }
    
            }
    
        }
    
    
        private static void initializeWordList()
        {
            words = new WordList();
            words.Add("test");         // Contains: test
            words.Add("dog");          // Contains: test, dog
            words.Insert(1, "shit"); // Contains: test, shit, dog
            words.Sort();
        }
    
    
        // ****** PICK NUMBER OF GUESSES ******
    
        private static void pickNumGuesses(ref int numGuessesInt)
        {
            string numGuessesString = "";
            Console.WriteLine("Pick a number of guesses");
            numGuessesString = Console.ReadLine();
            try
            {
                numGuessesInt = Convert.ToInt32(numGuessesString);
                if (!(numGuessesInt <= 20 & numGuessesInt >= 1))
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                numGuessesInt = -1;
                Console.WriteLine("Error: Invalid Number of Guesses");
            }
        }
    
        //PICK WORD
    
        private static string PickWord()
        {
            return words[randomGen.Next(0, words.Count() - 1)];
        }
    
    
        // ****** Display word ******
    
        private static string displayWord(List<char> guessedCharacters, string word)
        {
            string returnedWord = "";
            if (guessedCharacters.Count == 0)
            {
                foreach (char letter in word)
                {
                    returnedWord += "_ ";
                }
                return returnedWord;
            }
            foreach (char letter in word)
            {
                bool letterMatch = false;
                foreach (char character in guessedCharacters)
                {
                    if (character == letter)
                    {
                        returnedWord += character + " ";
                        letterMatch = true;
                        break;
                    }
                    else
                    {
                        letterMatch = false;
                    }
                }
                if (letterMatch == false)
                {
                    returnedWord += "_ ";
                }
            }
            return returnedWord;
        }
    
    
        // ****** Guess letter ******
    
        static void guessLetter(List<char> guessedCharacters, string word, string wordToDisplay, ref int numGuessesLeft)
        {
            string letters = "";
            foreach (char letter in guessedCharacters)
            {
                letters += " " + letter;
            }
            Console.WriteLine("Guess a letter");
            Console.WriteLine("Guessed Letters: " + letters);
            Console.WriteLine("Guesses Left: " + numGuessesLeft);
            Console.WriteLine(wordToDisplay);
            string guess = Console.ReadLine();
            char guessedLetter = 'a';
            try
            {
                guessedLetter = Convert.ToChar(guess);
                if (!Char.IsLetter(guessedLetter))
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid Letter Choice");
                //guessLetter(guessedCharacters, word, wordToDisplay, ref numGuessesLeft);
            }
            bool repeat = false;
            for (int i = 0; i < guessedCharacters.Count; i++)
            {
                if (guessedCharacters[i] == guessedLetter)
                {
                    Console.WriteLine("Error: Invalid Letter Choice");
                    repeat = true;
                    //guessLetter(guessedCharacters, word, wordToDisplay, ref numGuessesLeft);
                }
            }
            if (repeat == false)
            {
                guessedCharacters.Add(guessedLetter);
                numGuessesLeft -= 1;
            }
        }
    
        // ****** Check to see if player wants to play again. ******
    
        static void checkIfPlayAgain()
        {
            Console.WriteLine("Would you like to play again? (y/n)");
            string playAgain = Console.ReadLine();
            if (playAgain == "n")
            {
                Environment.Exit(1);
            }
        }
    }
