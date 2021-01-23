    public static IEnumerable<IEnumerable<T>> SplitBetween<T>(this IEnumerable<T> source,
                                                              Func<T, bool> separatorSelector,
                                                              bool includeSeparators = false)
    {
        using (var x = source.GetEnumerator())
            while (x.MoveNext())
                if (!separatorSelector(x.Current))
                    yield return SplitBetweenInner<T>(x, separatorSelector, includeSeparators);
    }
    static IEnumerable<T> SplitBetweenInner<T>(IEnumerator<T> x, 
                                               Func<T, bool> separatorSelector,
                                               bool includeSeparators)
    {
        yield return x.Current;
        while (x.MoveNext())
            if (!separatorSelector(x.Current))
                yield return x.Current;
            else
                yield break;
    }
