    public static IEnumerable<TSource> GetFirsts<TSource, TKey> (this IEnumerable<TSource> source,
                                                                 Func<TSource, TKey> selector,
                                                                 TKey zeroValue)
    {
        var set = new HashSet<TKey>();
        foreach (var item in source)
        {
            if (selector(item).Equals(zeroValue) || set.Add(selector(item)))
                yield return item;
        }
    }
