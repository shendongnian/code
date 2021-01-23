    static void TestRegEx()
    {
        string input = "sdsafff RewrittenQuery 1sdfs se1adjust  wer aasdfsd";
        Match m = Regex.Match(input, @"RewrittenQuery(?<A1>.{1,})adjust");
        if (m.Success)
            Console.WriteLine(m.Groups["A1"]);
        else
            Console.WriteLine("Didn't match");
    }
