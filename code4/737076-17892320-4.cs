    private static int stringMatches(string textToQuery, string[] stringsToFind)
    {
        var pattern = String.Join("|", stringsToFind.Select(s => @"\b" + s + @"\b"));
        return Regex.Matches(textToQuery, pattern, RegexOptions.IgnoreCase).Count;
    }
