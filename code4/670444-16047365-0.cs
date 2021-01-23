    public static IEnumerable<string> PossiblePaths(string basePath)
    {
        return PossiblePaths(basePath.Split(new[] { "/" }, 
                             StringSplitOptions.RemoveEmptyEntries));
    }
    
    private static IEnumerable<string> PossiblePaths(IEnumerable<string> segments, 
                                                     string current = "/")
    {
        if (segments.Count() == 0)
        {
            return new string[0];
        }
        else
        {
            string next = current + segments.First();
            return new[] { next, next + "/default" }
                             .Concat(PossiblePaths(segments.Skip(1), next + "/"));
        }
    }
