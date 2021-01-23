    public static IEnumerable<string> ProjectAndSeparateMany<T>(
        this IEnumerable<T> items, string separator, Func<T, object>... projections)
    {
        return projections.Select(projection => items.Select(projection)
                                                     .Separate(separator);
    }
