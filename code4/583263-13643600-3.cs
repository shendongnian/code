    bool IsSegmentInUrl(string url, string segment)
    {
        string pattern = String.Format(".*/{0}(/|$)", segment);
        return Regex.IsMatch(url, pattern, RegexOptions.IgnoreCase);
    }
