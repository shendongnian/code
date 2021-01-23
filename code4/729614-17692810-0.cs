    public static bool AllTrue(this IEnumerable<bool> source)
    {
        return source.All(b => b);
    }
    public static bool AllFalse(this IEnumerable<bool> source)
    {
        return source.All(b => !b);
    }
