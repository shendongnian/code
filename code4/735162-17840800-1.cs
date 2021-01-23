    private static Match FindMatch(string input)
    {
        if (input.Count() < 12)
        {
            return Regex.Match(input, @"...", RegexOptions.IgnoreCase);
        }
    
        return Regex.Match(input, @"...", RegexOptions.IgnoreCase);
    }
    var match = FindMatch(wordList[i].Text);
    if (match.Success)
    { ... }
