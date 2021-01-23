    string pattern = @"(\w+|[,-?])";
    string input = "How was your 7 day - Andrew, Jane?";
    
    List<string> words = new List<string>();
    
    Regex regex = new Regex(pattern);
    
    if (regex.IsMatch(input))
    {
        MatchCollection matches = regex.Matches(input);
    
        foreach (Match m in matches)
            words.Add(m.Groups[1].Value);
    }
