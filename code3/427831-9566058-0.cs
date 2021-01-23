    public static void MyExtension<T>(this IEnumerable<T> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
     
        // ...
    }
