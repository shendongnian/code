    public static IEnumerable<string> MatchingStringsCaseInsensitive(string haystack, IEnumerable<string> needles)
    {
        return needles.Where(needle => haystack.ToLower().Contains(needle.ToLower()));
    }
    
