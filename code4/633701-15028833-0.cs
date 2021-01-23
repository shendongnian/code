    static void Main(string[] args)
    {
        var s = @"[_fesd][009] Statement";
        var unwanted = @"_[]";
        
        var sanitizedS = s
            .Where(i => !unwanted.Contains(i))
            .Aggregate<char, string>("", (a, b) => a + b);
        Console.WriteLine(sanitizedS);
        // output: fesd009 Statement
    }
