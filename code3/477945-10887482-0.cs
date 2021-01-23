    public static IEnumerable<int> GetIndexes<T>(this IEnumerable<T> items, 
        Func<T, bool> predicate)
    {
        int i = 0;
        foreach (T item in items)
        {
           if (predicate(item))
               yield return i;
           i++;
        }
    }
