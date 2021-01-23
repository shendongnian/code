    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication58
    {
        class Program
        {
            static void Main()
            {
                string input =
                    @"I'm working with a txt or htm file. And currently I'm looking up the document char by char, using for loop, but I need to look up the text word by word, and then inside the word char by char. How can I do this?";
                var list = from Match match in Regex.Matches(input, @"\b\S+\b")
                           select match.Value; //Get IEnumerable of words
                foreach (string s in list) 
                    Console.WriteLine(s); //doing something with it
                Console.ReadKey();
            }
        }
    }
