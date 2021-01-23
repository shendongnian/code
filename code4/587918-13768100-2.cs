    public static IEnumerable<IEnumerable<T>> SubSets(
        this IEnumerable<T> source)
    {
        var count = source.Count();
        if (count > 64)
        {
            throw new OverflowException("Not Supported ...");
        }
        var limit = (ulong)(1 << count) - 2;
        for (var i = limit; i > 0; i--)
        {
            yield return source.SubSet(i);
        }
    }
    private static IEnumerable<T> SubSet<T>(
        this IEnumerable<T> source,
        ulong bits)
    {
        var check = (ulong)1;
        foreach (var t in source)
        {
            if ((bits & check) > 0)
            {
                yield return t;
            }
            check <<= 1;
        }
    }
