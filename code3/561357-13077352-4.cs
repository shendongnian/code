    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace StackOverflow.Demos
    {
        class Program
        {
            const string OutputFormat = "{0}: {1}";
            public static void Main(string[] args)
            {
                new Program("Another great story and another great adventure.");
                Console.WriteLine("Done");
                Console.ReadKey();
            }
            public Program(string userInput)
            {
                //break string into words
                IEnumerable<IGrouping<string, int>> words = Regex.Split(userInput, @"\W+").GroupBy(word => word.ToLowerInvariant(), word => 1); //nb converting word to lower case to avoid case sensitive comparisons in grouping - I can keep the original value(s) by replacing "word => 1" with "word => word" if needed
                Console.WriteLine("\nWords in alphabetic order");
                foreach (IGrouping<string, int> wordInfo in words.OrderBy(word => word.Key))
                {
                    Console.WriteLine(string.Format(OutputFormat, wordInfo.Key,wordInfo.Count()));
                }
                Console.WriteLine("\nWords in descending alphabetic order");
                foreach (IGrouping<string, int> wordInfo in words.OrderByDescending(word => word.Key))
                {
                    Console.WriteLine(string.Format(OutputFormat, wordInfo.Key, wordInfo.Count()));
                }
                Console.WriteLine("\nWords by frequency (desc)");
                foreach (IGrouping<string, int> wordInfo in words.OrderByDescending(word => word.Count()))
                {
                    Console.WriteLine(string.Format(OutputFormat, wordInfo.Key, wordInfo.Count()));
                }
            }
        }
    }
