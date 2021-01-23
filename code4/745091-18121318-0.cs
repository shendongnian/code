    public static IEnumerable<T> Concat<T>(params IEnumerable<T>[] args)
    {
        foreach (IEnumerable<T> collection in args)
        {
            foreach (T item in collection)
            {
                yield return item;
            }
        }
    }
