    public static IEnumerable<string> 
    GetRootPathsOfSet(this IEnumerable<string> paths)
    {
        var sortedSet = new SortedSet<string>(paths,
                                              StringComparer.CurrentCultureIgnoreCase);
        string currRoot = null;
        foreach (var p in sortedSet)
        {
            if (currRoot == null ||
               !p.StartsWith(currRoot, StringComparison.InvariantCultureIgnoreCase))
            {
                currRoot = p;
                yield return currRoot;
            }
        }
    }
