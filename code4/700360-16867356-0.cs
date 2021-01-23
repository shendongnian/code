    public string[] ExtractEmails(string str)
    {
        string RegexPattern = @"\b[A-Z0-9._-]+@[A-Z0-9][A-Z0-9.-]{0,61}[A-Z0-9]\.[A-Z.]{2,6}\b";
        // Find matches
        System.Text.RegularExpressions.MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(str, RegexPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        string[] MatchList = new string[matches.Count];
        // add each match
        foreach (System.Text.RegularExpressions.Match match in matches)
            MatchList[c] = match.ToString();
        return MatchList;
    }
