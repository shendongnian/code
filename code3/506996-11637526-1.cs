    public static void CopyToList<T>(this IEnumerable<T> source, List<T> destination)
    {
        // parameter validation ommited for brevity
        destination.Clear();
        foreach (T item in source)
        {
            destination.Add(item);
        }
    }
