    using System;
    using System.Text.RegularExpressions;
    namespace RegExIssues
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Properly escaped to capture matches.
                string lordcheeto = @".*?(\[A\]\d+|\d+|A\[\d+\]).*?";
                string input = "[A]16 and 5th and A[20] and 15";
                executePattern("lordcheeto's", input, lordcheeto);
                Console.ReadLine();
            }
            static void executePattern(string version, string input, string pattern)
            {
                // Avoiding repitition for this example.
                Console.WriteLine("Using {0} pattern:", version);
                // Needs to be trimmed.
                var result = Regex.Split(input.Trim(), pattern);
                // Pipe included to highlight empty strings.
                foreach (var m in result)
                    Console.WriteLine("|{0}", m);
                // Extra space.
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
