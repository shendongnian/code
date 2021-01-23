    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var random = new Random();
    
                var iTemplate = "Hi, this is a template with several words on it and I want to place random dots on 4 different random places every time I run the function";    
                var result = iTemplate;
    
                while (new Regex("\\. ").Matches(result).Count < 4)
                    result = result.TrimEnd()
                        .Split(' ')
                        .Aggregate(
                            string.Empty,
                            (current, word) =>
                                current + (word + (((word.EndsWith(".") || (random.Next(1, 100) % 10) != 0)) ? "" : new string('.', random.Next(1, 7))) + " ")
                            );
                
                Console.WriteLine(result);
                Console.Read();
            }
        }
    }
