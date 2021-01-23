    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source,
                                                       Func<T, bool> separatorPredicate,
                                                       bool includeEmptyEntries = false,
                                                       bool includeSeparator = false)
    {
        using (var x = source.GetEnumerator())
            while (x.MoveNext())
                if (!separatorPredicate(x.Current))
                    yield return x.YieldTill(separatorPredicate, includeSeparator);
                else if (includeEmptyEntries)
                {
                    if (includeSeparator)
                        yield return Enumerable.Repeat(x.Current, 1);
                    else
                        yield return Enumerable.Empty<T>();
                }
    }
    static IEnumerable<T> YieldTill<T>(this IEnumerator<T> x, 
                                       Func<T, bool> separatorPredicate,
                                       bool includeSeparator)
    {
        yield return x.Current;
        while (x.MoveNext())
            if (!separatorPredicate(x.Current))
                yield return x.Current;
            else
            {
                if (includeSeparator)
                    yield return x.Current;
                yield break;
            }
    }
