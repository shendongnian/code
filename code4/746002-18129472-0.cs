    class Program
    {
        static void Main(string[] args)
        {
            string rawInput = @"**Hello {Full{Name}, I { wanted to 
                inform that your product {{ProductName} is ready.
                Please come to our } address {Addr{Street}ess} to get it!**";
            string pattern = "^[^{}]*" +
                           "(" +
                           "((?'Open'{)[^{}]*)+" +
                           "((?'Close-Open'})[^{}]*)+" +
                           ")*" +
                           "(?(Open)(?!))$";
            var tokens = Regex.Match(
                Regex.Match(rawInput, @"{[\s\S]*}").Value,
                pattern,
                RegexOptions.Multiline)
                    .Groups["Close"]
                    .Captures
                    .Cast<Capture>()
                    .Where(c =>
                        !c.Value.Contains('{') &&
                        !c.Value.Contains('}'))
                    .ToList();
            tokens.ForEach(c =>
            {
                Console.WriteLine(c.Value);
            });
        }
    }
