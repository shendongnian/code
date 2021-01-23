    using System;
    using System.Linq
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            string[] words = System.IO.File.ReadAllLines(@"C:\Users\ADMIN\Desktop\Letters\Letters.txt");
            int LengthOfArray = words.Length;
            Random rnd = new Random();
            int random = rnd.Next(1, 3);
            char[] letters = words[random].ToCharArray();
            bool WordIsHidden = true;
            char hiddenChar = '_';
            //fix 1 use a list or hashset or similar to store the selected chars
            var guessed = new List<char>();
            var retry = true;
            while (retry = true)
            {
                Console.WriteLine(letters);
                //fix 2, loop over the letters, checking whether they have been guessed
                foreach(var c in letters)
                {
                    if (guessed.Contains(c))
                        Console.Write(c);
                    else
                        Console.Write("_");
                }
                Console.WriteLine("\nEnter a letter!");
                char letter = char.Parse(Console.ReadLine());
                if (words[random].Contains<char>(letter))
                {
                    WordIsHidden = false;
                    guessed.Add(letter);
                }
                else
                {
                    if (WordIsHidden == true)
                    {
                        guessed.Clear();
                        Console.WriteLine("You guessed wrong!");
                    }
                }
    
            }
        }
    };
