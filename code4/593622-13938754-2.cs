    public static IEnumerable<T> WhereOrFirstOfRest<T>(
        this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        T firstItem = default(T);
        bool firstStored = false;
        bool predicateReturnedItems = false;
        foreach (var item in collection)
        {
            if (!firstStored)
            {
                firstItem = item;
                firstStored = true;   
            }
            if (predicate(item))
            {
                yield return item;
                predicateReturnedItems = true;
            }
        }
        if (!predicateReturnedItems && !first)
        {
            yield return firstItem;
        }
    }
