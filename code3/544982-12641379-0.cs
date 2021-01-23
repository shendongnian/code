    public static IEnumerable<TResult> Zip<TFirst, TSecond, TThird, TResult>
        (this IEnumerable<TFirst> source, IEnumerable<TSecond> second
        , IEnumerable<TThird> third
        , Func<TFirst, TSecond, TThird, TResult> selector)
    {
        using(IEnumerator<TFirst> iterator1 = source.GetEnumerator())
        using(IEnumerator<TSecond> iterator2 = second.GetEnumerator())
        using (IEnumerator<TThird> iterator3 = third.GetEnumerator())
        {
            while (iterator1.MoveNext() && iterator2.MoveNext()
                && iterator3.MoveNext())
            {
                yield return selector(iterator1.Current, iterator2.Current,
                    iterator3.Current);
            }
        }
    }
