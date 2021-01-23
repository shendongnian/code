    public static IEnumerable<IEnumerable<T>> Chop<T>(
        this IEnumerable<T> source,
        int chopCount)
    {
        var chops = new IList<T>[chopCount];
        for (i = 0; i < chops.Length; i++)
        {
            chops[i] = new List<T>();
        }
        var nextChop = 0;
        foreach (T item in source)
        {
            chop[nextChop].Add(item);
            nextChop = nextChop == chopCount - 1 ? 0 : nextChop + 1;
        }
        for (i = 0; i < chops.Length; i++)
        {
            yield return chops[i];
        }   
    }
