    using System;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Declaring integers to be used 
                int countedWords = 0; 
                int cap_count = 0;
                int lower_count = 0;
                int space_count = 0;
    
                Console.WriteLine("Please enter a string\n");
                string inputString = Console.ReadLine();
    
                countedWords = inputString.Split(' ').Length; //counts words
                Console.WriteLine("\nREPORT FOR: " + inputString + "\n");
                Console.WriteLine("WORDCOUNT: " + countedWords);
    
    
                foreach (char c in inputString) 
                {
                    //if is upper case add to cap_count
                    if (Char.IsUpper(c))
                        cap_count++;
                    //if char is a separator add to space_count
                    else if (char.IsSeparator(c))
                        space_count++;
                    //all else will be lower case values.
                    else
                        lower_count++;
                }
    
                //display results.
                Console.WriteLine("Number of Letters: " + (cap_count + lower_count));
                Console.WriteLine("Number of capital Letters: " + cap_count);
                Console.WriteLine("Number of lower case Letters: " + lower_count);
                Console.WriteLine("Number of spaces: " + cap_count);
    
    
                Console.ReadLine();
            }
        }
    }
