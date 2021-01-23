    private static string DeterminePattern(string input)
    {
        if (input.Count() < 12)
        {
            return @"...";
        }
    
        return @"...";
    }
    var match = Regex.Match(wordList[i].Text, DeterminePattern(wordList[i].Text), RegexOptions.IgnoreCase);
    if (match.Success)
    { ... }
