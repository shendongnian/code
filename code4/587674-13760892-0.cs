    List<string> strings = new List<string>()
    {
        "-Xyz",
        "--Xyz",
        "---Xyz",
        "-Xyz-Abc",
        "--Xyz-Abc"
    };
    foreach (var s in strings)
    {
        string temp;
        // String.Trim Method
        char[] charsToTrim = { '*', ' ', '\'', '-', '_' }; // Add more
        temp = s.TrimStart(charsToTrim);
        Console.WriteLine(temp);
        // Enumerable.SkipWhile Method
        // Char.IsPunctuation Method (se also Char.IsLetter, Char.IsLetterOrDigit, etc.)
        temp = new String(s.SkipWhile(x => Char.IsPunctuation(x)).ToArray());
        Console.WriteLine(temp);
    }
