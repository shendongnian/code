    public static IEnumerable<IList<T>> Buffer<T>(this IEnumerable<T> orig, int count)
    {
        return orig.Select((o,i) => Tuple.Create(o, i / count))
                   .GroupBy(x => x.Item2)
                   .Select(g => g.Select(x => x.Item1).ToList());
    }
