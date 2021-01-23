    static void Main(string[] args)
    {
        string input = "<div>This is a test</div><div class=\"something\">This is ANOTHER test</div>";
        string pattern = "<div.*?>(.*?)<\\/div>";
    
        MatchCollection matches = Regex.Matches(input, pattern);
        Console.WriteLine("Matches found: {0}", matches.Count);
    
        if (matches.Count > 0)
            foreach (Match m in matches)
                Console.WriteLine("Inner DIV: {0}", m.Groups[1]);
    
        Console.ReadLine();
    }
