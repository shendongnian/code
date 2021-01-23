    public static void RemoveAll<T>(this IList<T> source, Predicate<T> predicate)
    {
        // TODO: Argument non-nullity validation
        // Optimization
        List<T> list = source as List<T>
        if (list != null)
        {
            list.RemoveAll(predicate);
            return;
        }
        // Slow way
        for (int i = source.Count - 1; i >= 0; i--)
        {
            if (predicate(source[i]))
            {
                source.RemoveAt(i);
            }
        }
    }
