    [Conditional("DEBUG")]
    public static void Print<T>(this IEnumerable<T> collection)
    {
        foreach(T item in collection)
        {
            Console.WriteLine(item);
        }
    }
