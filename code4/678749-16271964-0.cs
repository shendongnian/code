    public static bool AllDuplicatesSameCase(IEnumerable<string> input)
    {
        var sensitive = new HashSet<String>(input, StringComparer.InvariantCulture);
        var insensitive = new HashSet<String>(input, 
              StringComparer.InvariantCultureIgnoreCase);
        return sensitive.Count == insensitive.Count;
    }
