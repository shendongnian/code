    private static string GetProperty(string source, string propertyName)
    {
        string pattern = String.Format("(?<={0}:\\s*)[^\\s]+", propertyName);
        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
        return regex.Match(source).Value;
    }
