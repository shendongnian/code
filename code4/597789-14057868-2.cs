    public static IEnumerable<T> Where(this IEnumerable<T> source,
                                       Func<bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }
