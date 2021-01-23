    public static void SetLast<T>(this IList<T> source, T value)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        
        if (source.Count == 0)
        {
            throw new ArgumentException("cannot be empty", "source");
        }
        source[source.Count - 1] = value;
    }
