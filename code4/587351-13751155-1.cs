    public static IEnumerable<TResult> FirstOrEmpty<TResult>(
        this IEnumerable<TResult> source,
        Func<TResult, bool> predicate)
    {
        return source.Where(predicate).Take(1);
    }
