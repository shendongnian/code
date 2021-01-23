    public static bool SetEquals(this IList first, IList second)
    {
        if (first.Count != second.Count)
            return false;
    
        return first.OfType<object>().Intersect(second.OfType<object>())
            .Count() < first.Count;
    }
