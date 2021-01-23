    public static void RemoveNulls<T>(this IList<T> collection) where T : class
    {
        for (var i = collection.Count-1; i >= 0 ; i--)
        {
            if (collection[i] == null)
                collection.RemoveAt(i);
        }
    }
