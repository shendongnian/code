    class Program
    {
        static void Main(string[] args)
        {
            var input = "BK-TS00023,X1-TS00000101,X4-A10000024,Y1-3,";
            var filter = new[] { "BK Books", "X1 Serials" };
            Console.WriteLine(input);
            var result = IncreaseWithFilter(input, filter);
            Console.WriteLine(result);
        }
        private static string IncreaseWithFilter(
            string input,
            IEnumerable<string> filter)
        {
            var truncatedFilter = filter.Select(f => f.Substring(0, 2));
            var result = Regex.Replace(input, @"([^,].*?)\d+(?=,)",
                (match1) =>
                {
                    var value = match1.Value;
                    if (truncatedFilter.Any(f => match1.Value.StartsWith(f)))
                    {
                        value = Regex.Replace(match1.Value, @"(?<=)\d+",
                            (match2) =>
                            {
                                return (Convert.ToInt32(match2.Value) + 1)
                                    .ToString()
                                    .PadLeft(match2.Value.Length, '0');
                            });
                    }
                    return value;
                });
            return result;
        }
    }
