    public static IEnumerable<Tuple<T, T>> Pair<T>(this IEnumerable<T> source)
    {
        T previous;
        using (var iterator = source.GetEnumerator())
        {
            if (iterator.MoveNext())
                previous = iterator.Current;
            else
                yield break;
            while(iterator.MoveNext())
            {
                yield return Tuple.Create(previous, iterator.Current);
                previous = iterator.Current;
            }
        }
    }
