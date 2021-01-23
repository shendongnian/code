    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace HomeWork
    {
        class Alphabets
        {
            static void Main(string[] args)
            {
                string sentence = null;
                string findString = null;
                int numericCount;
                int upperCount;
                int lowerCount;
                int specialCount;
                int countBlankSpace;
                int countWord;
                Console.Write("Please enter a string: ");
                sentence = Console.ReadLine();
                numericCount = Regex.Matches(sentence, @"\d").Count;
                upperCount = Regex.Matches(sentence, @"[A-Z]").Count;
                lowerCount = Regex.Matches(sentence, @"[a-z]").Count;
                specialCount = Regex.Matches(sentence, @"[!""£$%^&*())]").Count;
                countBlankSpace = new Regex(" ").Matches(sentence).Count;
                countWord = Regex.Matches(sentence, @"[\S]+").Count;
                Console.WriteLine("Report on {0}",sentence);
                Console.WriteLine("# of spaces {0}", countBlankSpace);
                Console.WriteLine("# of lower {0}", lowerCount);
                Console.WriteLine("# of upper {0}", upperCount);
                Console.WriteLine("# of word {0}", countWord);
                Console.WriteLine("# of Special Characters {0}", specialCount);
                Console.Write("Please enter a substring:");
                findString = Console.ReadLine();
                Alphabets.findSubString(findString, sentence);
                Console.WriteLine("\nLowercase Letters \n");
                Alphabets.lowerLetters(sentence);
                Console.WriteLine("\nUppercase Letters \n");
                Alphabets.upperLetters(sentence);
                Console.ReadLine();
            }
            public static void lowerLetters(string sentence)
            {
                int[] upper = new int[(int)char.MaxValue];
                // 1.
                // Iterate over each character.
                foreach (char t in sentence)
                {
                    // Increment table.
                    upper[(int)t]++;
                }
    
                // 2.
                // Write all letters found.
                for (int i = 0; i < (int)char.MaxValue; i++)
                {
                    if (upper[i] > 0 &&
                    char.IsLower((char)i))
                    {
                        Console.WriteLine("Letter: {0}  = {1}",
                            (char)i,
                            upper[i]);
                    }
                }
            }
    
            public static void upperLetters(string sentence)
            {
                int[] upper = new int[(int)char.MaxValue];
                // 1.
                // Iterate over each character.
                foreach (char t in sentence)
                {
                    // Increment table.
                    upper[(int)t]++;
                }
    
                // 2.
                // Write all letters found.
                for (int i = 0; i < (int)char.MaxValue; i++)
                {
                    if (upper[i] > 0 &&
                    char.IsUpper((char)i))
                    {
                        Console.WriteLine("Letter: {0} = {1}",
                            (char)i,
                            upper[i]);
                    }
                }
            }
    
            public static void findSubString(string findString, string sentence)
            {
                int findStringCount = 0;
                int startingPoint = 0;
    
    
                if (findString.Length <= sentence.Length)
                {
                    do
                    {
                        if (sentence.IndexOf(findString, startingPoint) != -1)
                        {
                            findStringCount++;
                            startingPoint = sentence.IndexOf(findString, startingPoint) + findString.Length;
                        }
    
                    } while (sentence.IndexOf(findString, startingPoint) != -1);
                }
                else
                {
                    Console.WriteLine("Substring is too long!");
                }
                Console.WriteLine("The number of times that {0} is found in the text is {1}", findString, findStringCount);
            }
           
        }
    }
