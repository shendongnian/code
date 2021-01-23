    MatchCollection m = new Regex("\\w+").Matches(input);
    List<string> words = new List<string>();
    foreach (Match item in m)
    {
        words.Add(item.Value);
    }
