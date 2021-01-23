    public bool CustomMatch(string input, string pattern)
    {
        pattern = "^" + Regex.Escape(pattern).Replace(@"\*", ".*") + "$";
        return Regex.IsMatch(input, pattern);
    }
