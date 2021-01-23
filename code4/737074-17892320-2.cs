    private static int stringMatches(string textToQuery, string[] stringsToFind)
    {
        string pattern = String.Join("|", stringsToFind);
        return Regex.Matches(textToQuery, pattern, RegexOptions.IgnoreCase).Count;
    }
