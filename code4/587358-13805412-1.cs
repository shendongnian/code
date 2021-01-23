    public static IEnumerable<TResult> FirstOrEmpty<TKey, TResult>(
        this IEnumerable<IGrouping<TKey, TResult>> source,
        Func<IGrouping<TKey, TResult>, bool> predicate
        )
    {
        return source.FirstOrDefault(predicate) ?? Enumerable.Empty<TResult>();
    }
