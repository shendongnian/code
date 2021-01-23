    public static IEnumerable<int> getIntsWithinN(int BaseInt, int Offset)
    {
        return getIntsWithinN(Enumerable.Empty<int>(), BaseInt, Offset);
    }
    public static IEnumerable<int> getIntsWithinN(this IEnumerable<int> source, int BaseInt, int Offset)
    {
        return source.Concat(Enumerable.Range(BaseInt - Offset, Offset * 2 + 1));
    }
