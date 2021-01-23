    Regex reg = new Regex(@"{@[\w|\d]+}");
    string input = "test {@name} this out";
    MatchCollection matches = reg.Matches(input);
    foreach (Match m in matches)
    {
        // Look up the value or whatever based on m.Value
        Console.WriteLine(m.Value);
    }
