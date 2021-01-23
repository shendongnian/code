    class Program
    {
        static void Main(string[] args)
        {
            var input = "BK-TS00023,X1-TS00000101,X4-A10000024,Y1-3,";
            var result = Regex.Replace(input, @"(?<=)\d+(?=,)", new MatchEvaluator(Increase));
        }
        private static string Increase(Match match)
        {
            return (Convert.ToInt32(match.Value) + 1).ToString().PadLeft(match.Value.Length, '0');
        }
    }
