    string[] entries = new string[7] {
        "800 (0) 123 - 1",
        "800 (1) 123",
        "(0)321 123",
        "1 (0) 1",
        "1 (12) (0) 1",
        "1 (0) (0) 1",
        "(9)156 (1) (0)"
    };
    foreach (string entry in entries)
    {
        var output = Regex.Replace(entry , @"\(0\)\s*\(0\)", "0");
        output = Regex.Replace(output, @"\s\(0\)", "");
        output = Regex.Replace(output, @"[^\d]", "");
        System.Console.WriteLine("---");
        System.Console.WriteLine(entry);
        System.Console.WriteLine(output);
    }
