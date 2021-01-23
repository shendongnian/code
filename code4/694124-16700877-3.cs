    public static IEnumerable<TResult> WithNext<T, TResult>(this IEnumerable<T> source, Func<T, T, TResult> selector)
    {
        using (var e = source.GetEnumerator())
        {
            if (!e.MoveNext()) yield break;
            T previous = e.Current;
            while (e.MoveNext())
            {
                yield return selector(previous, e.Current);
                previous = e.Current;
            }
            yield return selector(previous, default(T));
        }
    }
