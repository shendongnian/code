    public static IEnumerable<TItem> Extend<TItem>(
        this IEnumerable<TItem> source, 
        int n)
    {
        return source.Concat(Enumerable.Repeat(default(TItem), n))
                     .Take(n);
    }
