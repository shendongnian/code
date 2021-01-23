    public static IEnumerable<string> MatchingStringsCaseInsensitive(string haystack, IEnumerable<string> needles)
    {
        var h = haystack.ToLower();
        return needles.Where(needle => h.Contains(needle.ToLower()));
    }
    
