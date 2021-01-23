    Match match = regex.Match(your_search_text);
    if (match.Success)
    {
        Console.WriteLine(match.Groups[1].Value);
        Console.WriteLine(match.Groups[2].Value);
        Console.WriteLine(match.Groups[3].Value);
        Console.WriteLine(match.Groups[4].Value);
    }
