    public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(
        this IList<TSource> source, int size)
    {
        if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
        var enumerator = source.GetEnumerator();
        for (int i = 0; i < source.Count; i += size)
        {
            enumerator.MoveNext();
            yield return GetChunk(i, Math.Min(i + size, source.Count));
        }
        IEnumerable<TSource> GetChunk(int from, int toExclusive)
        {
            for (int j = from; j < toExclusive; j++)
            {
                enumerator.MoveNext();
                yield return source[j];
            }
        }
    }
