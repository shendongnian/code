    public static IEnumerable<string> Split_RemoveWhiteTokens(this string s, params char[] separator)
    {
        return s.Split(separator).
              Select(tag => tag.Trim()).
              Where(tag => !string.IsNullOrEmpty(tag));
    }
