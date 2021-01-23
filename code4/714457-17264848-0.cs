    public static int FindIndex<T>(
        this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        int i = 0;
        foreach (var item in collection)
        {
            if (predicate(item))
                return i;
            i++;
        }
        return -1;
    }
