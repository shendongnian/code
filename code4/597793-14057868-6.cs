    public static IEnumerable<T> Where<T>(this IEnumerable<T> source,
                                       Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }
