    public static IEnumerable<T> TakeIf<T>(this IEnumerable<T> source, 
                                           Func<T, T, bool> predicate)
    {
        var enumerator = source.GetEnumerator();
        if (!enumerator.MoveNext())
            yield break;
        yield return enumerator.Current;
        T previous = enumerator.Current;
        while (enumerator.MoveNext())
        {
            if (predicate(previous, enumerator.Current))
                yield return enumerator.Current;
            previous = enumerator.Current;
        }
    }
