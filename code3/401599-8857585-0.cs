    var patterns = new[] { "Type1", "Type2", "Type3" };
    Match match;
    foreach (string pattern in patterns)
    {
        match = Regex.Match(input, pattern);
        if (match.Success)
            break;
    }
