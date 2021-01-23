    public static IEnumerable<T> FirstOrEmpty<T>(this IEnumerable<T> source)
    {
        //TODO: null check arguments
        using (var iterator = source.GetEnumerator())
        {
            if (iterator.MoveNext())
                return new T[] { iterator.Current };
            else
                return Enumerable.Empty<T>();
        }
    }
    public static IEnumerable<T> FirstOrEmpty<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        return FirstOrEmpty(source.Where(predicate));
    }
