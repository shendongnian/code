    public static IEnumerable<IGrouping<string, TElement>> GroupBy<TElement>(
        this IEnumerable<TElement> source, params string[] properties)
    {
        return source.GroupBy(GetGroupKey<TElement>(properties).Compile());
    }
    
    public static IQueryable<IGrouping<string, TElement>> GroupBy<TElement>(
        this IQueryable<TElement> source, params string[] properties)
    {
        return source.GroupBy(GetGroupKey<TElement>(properties));
    }
