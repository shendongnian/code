    public static bool ContainsSegment(this string url, string segment)
    {
        string pattern = String.Format("http://.*/{0}(/|$)", segment);
        return Regex.IsMatch(url, pattern, RegexOptions.IgnoreCase);
    }
