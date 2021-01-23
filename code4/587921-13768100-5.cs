    public static IEnumerable<IEnumerable<T>> SubSets_Jodrell2<T>(
        this IEnumerable<T> source)
    {
        var list = source.ToList();
        var limit = (ulong)(1 << list.Count);
        for (var i = limit; i > 0; i--)
        {
            yield return list.SubSet(i);
        }
    }
    private static IEnumerable<T> SubSet<T>(
        this IList<T> source, ulong bits)
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (((bits >> i) & 1) == 1)
            {
                yield return source[i];
            }
        }
    }
