    using System;
    using System.Text.RegularExpressions;
    namespace RegEx
    {
        class Program
        {
            static void Main(string[] args)
            {
                string original = "([+\\-*/%()]{1}|[=<>!]{1,2}|[&|]{2})";
                string lordcheeto = @"\s*(==|&&|<=|>=|<|>)\s*";
                string input = "Name=='mynme' && CurrentTime<45 - 4";
                string input1 = "Name=='mynme' && CurrentTime<'2012-04-20 19:45:45'";
                string ridiculous = "Name == BLAH && !@#>=$%^&*()< ASDF &&    this          >          that";
                executePattern("original", input, original);
                executePattern("lordcheeto's", input, lordcheeto);
                executePattern("original", input1, original);
                executePattern("lordcheeto's", input1, lordcheeto);
                executePattern("original", ridiculous, original);
                executePattern("lordcheeto's", ridiculous, lordcheeto);
            }
            static void executePattern(string version, string input, string pattern)
            {
                // Avoiding repitition for this example.
                Console.WriteLine("Using {0} pattern:", version);
                // Needs to be trimmed.
                var result = Regex.Split(input.Trim(), pattern);
                // Pipes included to highlight whitespace trimming.
                foreach (var m in result)
                    Console.WriteLine("|{0}|", m);
                // Extra space.
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
