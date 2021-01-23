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
    
                var iTemplate = "this is a template and stuff";
    
                var result = iTemplate;
    
                while (new Regex("\\. ").Matches(result).Count < 4)
                    result = result.TrimEnd()
                        .Split(' ')
                        .Aggregate(
                            string.Empty,
                            (current, word) =>
                                current + (word + (((random.Next(1, 15) % 2) == 0) ? "" : new string    ('.', random.Next(1, 7))) + " ")
                            );
    
                Console.WriteLine(result);
                Console.Read();
            }
        }
    }
