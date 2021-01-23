    class Program
    {
        static string ConvertMathFunc(Match m)
        {
            Console.WriteLine(m.Groups["mathfunc"]);
            Console.WriteLine(m.Groups["argument"]);
            double arg;
            if (!double.TryParse(m.Groups["argument"].Value, out arg))
                throw new Exception(String.Format("Math function argument could not be parsed to double", m.Groups["argument"].Value));
            switch (m.Groups["mathfunc"].Value)
            {
                case "tan": return Math.Tan(arg).ToString();
                case "cos": return Math.Cos(arg).ToString();
                case "sin": return Math.Sin(arg).ToString();
                default:
                    throw new Exception(String.Format("Unknown math function '{0}'", m.Groups["mathfunc"].Value));
            }
        }
        static void Main(string[] args)
        {
            string input = "10 - 5 * tan(40) - cos(0) - 40 * sin(90);";
            Regex pattern = new Regex(@"(?<mathfunc>(tan|cos|sin))\((?<argument>[0-9]+)\)");
            string output = pattern.Replace(input, new MatchEvaluator(Program.ConvertMathFunc));
            Console.WriteLine(output);
        }
    }
