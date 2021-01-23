    public Dictionary<string, int> countWordsInStatus(string status, string[] dictArray)
    {
        var wordPattern = new Regex(@"\w+");
        return 
            (from Match m in wordPattern.Matches(status)
             where dictArray.Contains(m.Value)
             group m by m.Value)
            .ToDictionary(g => g.Key, g => g.Count(),
                StringComparer.CurrentCultureIgnoreCase);
    }
