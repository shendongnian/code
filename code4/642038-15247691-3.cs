    public static void ForEach(this IEnumerable<T> source, Action<T> action)
    {
        // Error handling omitted
    
        // Cycle through the items, perform action.
        foreach (var item in source)
        {
            // Perform action.
            action(item);
        }
    }
