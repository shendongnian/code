    public static void ForEach<T>(this IEnumerable<T> en, Action<T> action)
    {
        foreach(T item in en)
        {
            action(item);
        }
    }
