    public static IEnumerable<int> SelectMaxOfEvery(this IEnumerable<int> source, int n)
    {
        int i = 0;
        int currentMax = 0;
        foreach (int d in source)
        {
            if (i++ == 0)
                currentMax = d;
            else
                currentMax = Math.Max(d, currentMax);
            if (i == n)
            {
                i = 0;
                yield return currentMax;
            }
        }
        if (i > 0)
            yield return currentMax;
    }
    //...
    IEnumerable<int> filtered = raw.SelectMaxOfEvery(3);
