    public static IEnumerable<T> PackGroups<T>(this IEnumerable<T> e)
    {
        T lastItem = default(T);
        bool first = true;
        foreach(T item in e)
        {
            if (!first && object.Equals(item, lastItem))
                continue;
            first = false;
            yield return item;
            lastItem = item;
        }
    }
