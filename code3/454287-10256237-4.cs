    using System;
    using System.Text.RegularExpressions;
    namespace RegEx
    {
        class Program
        {
            static void Main(string[] args)
            {
                string lordcheeto = @"\s*('.*?'|&&|==|<=|>=|<|>|\(|\)|\+|-|\|\|)\s*";
                string input = "Name=='mynme' && CurrentTime<45 - 4";
                string input1 = "Name=='mynme' && CurrentTime<'2012-04-20 19:45:45'";
                string input2 = "((1==2) && 2-1==1) || 3+1==4 && Name=='Stefan+123'";
                executePattern("lordcheeto's", input, lordcheeto);
                executePattern("lordcheeto's", input1, lordcheeto);
                executePattern("lordcheeto's", input2, lordcheeto);
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
