    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication3
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                List<string> words = new List<string>();
                int tries = 0;
                Random rand = new Random();
                var currentLetters = new List<char>();
                int randomword = rand.Next(1, 5);
                string word = "";
    
                Console.WriteLine("Please Enter 5 Words into the System");
                Console.WriteLine();
    
                for (int i = 0; i < 5; i++)
                {
                    words.Add(Console.ReadLine());
                    Console.Clear();
                }
    
                Console.WriteLine("For Display Purposes. Here are Your 5 Words");
                Console.WriteLine("===========================================");
                Console.WriteLine();
                foreach (var item in words)
                {
                    Console.WriteLine(item);
                }
    
                Console.WriteLine();
                Console.WriteLine("Now Guess The word given Below");
                Console.WriteLine();
    
                switch (randomword)
                {
                    case 1:
                        //Gets the List index 0 - 1st word in the list
                        word = words[0];
                        tries = word.Length;
                        break;
                    case 2:
                        word = words[1];
                        tries = word.Length;
                        break;
                    case 3:
                        word = words[2];
                        tries = word.Length;
                        break;
                    case 4:
                        word = words[3];
                        tries = word.Length;
                        break;
                    case 5:
                        word = words[4];
                        tries = word.Length;
                        break;
                    default:
                        break;
                }
                //Default + addition to the Length
                tries += 2;
    
                Console.WriteLine();
                Console.WriteLine("You Have {0} + tries", tries);
                //Works for the 1st Guess
                do
                {
                    char guess = char.Parse(Console.ReadLine());
                    if (!currentLetters.Contains(guess))
                    {
                        currentLetters.Add(guess);
                        foreach (var l in word.ToCharArray().Intersect(currentLetters).ToArray())
                        {
                            word = word.Replace(l, '_');
                        }
                    }
                    Console.WriteLine(word);
                } //If my word contains A "_" i will keep looping
                while (word.Contains("_"));
    
            Console.ReadKey();
        }
    }
}
