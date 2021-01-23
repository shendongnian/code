    List<string> strings = new List<string>();
    GenerateStringsRecursive(strings, n, "");
    foreach (string s in strings)
    {
        Console.WriteLine(s);
    }
