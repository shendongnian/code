    class Program
    {
        static List<string> filter = new List<string>() { "BK", "X1" };
        static void Main(string[] args)
        {
            var input = "BK-TS00023,X1-TS00000101,X4-A10000024,Y1-3,";
            Console.WriteLine(input);
            var result = Regex.Replace(input, @"([^,].*?)\d+(?=,)", new MatchEvaluator(Increase1));
            Console.WriteLine(result);
        }
        private static string Increase1(Match match)
        {
            var result = match.Value;
            if (filter.Any(f => match.Value.StartsWith(f)))
            {
                result = Regex.Replace(match.Value, @"(?<=)\d+", new MatchEvaluator(Increase2));
            }
            return result;
        }
        private static string Increase2(Match match)
        {
            return (Convert.ToInt32(match.Value) + 1).ToString().PadLeft(match.Value.Length, '0');
        }
    }
