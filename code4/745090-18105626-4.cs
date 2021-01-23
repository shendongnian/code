    public static void ForEachAll<T>(Action<T> action, 
        params System.Collections.IEnumerable[] collections)
    {
        foreach(var collection in collections)
            foreach(var item in collection.Cast<T>())
                action(item);
    }
