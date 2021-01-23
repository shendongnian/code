    public static IEnumerable<Tuple<T, T>> GroupAdjacent<T>(IEnumerable<T> source)
    {
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                yield break;
            }
            T previous = iterator.Current;
            while (iterator.MoveNext())
            {
                yield return Tuple.Create(previous, iterator.Current);
            }
        }
    }
