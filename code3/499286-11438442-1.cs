    public static IEnumerable<IEnumerable<TSource>> Split<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
    {
        List<TSource> group = new List<TSource>();
        foreach (TSource item in source)
        {
            if (predicate(item))
            {
                yield return group.AsEnumerable();
                group = new List<TSource>();
            }
            else
            {
                group.Add(item);
            }
        }
        yield return group.AsEnumerable();
    }
