    public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(
        this IEnumerable<TSource> source, int size)
    {
        if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
        using (var enumerator = source.GetEnumerator())
        {
            int i = 0;
            while (enumerator.MoveNext())
            {
                if (i % size != 0) throw new InvalidOperationException(
                    "The enumeration is out of order.");
                i++;
                yield return GetBatch();
            }
            IEnumerable<TSource> GetBatch()
            {
                while (true)
                {
                    yield return enumerator.Current;
                    if (i % size == 0 || !enumerator.MoveNext()) break;
                    i++;
                }
            }
        }
    }
