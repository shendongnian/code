    private string SearchInfo(String pattern)
    {            
        MatchCollection matches = Regex.Matches(rtxtText.Text, pattern);
        if (matches.Count == 0)
            return String.Empty;
    
        StringBuilder sb = new StringBuilder();
        foreach (Match match in matches)
            sb.AppendLine(match.Value);
    
        return sb.ToString();
    }
