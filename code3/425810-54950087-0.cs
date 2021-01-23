    public static void RemoveAll<T>(this IList<T> collection)
    {
        while (collection.Count > 0)
        {
            if (collection.Count == 1)
            {
                try
                {
                    collection.RemoveAt(collection.Count - 1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    if (collection.Count > 0)
                        throw;
                }
            }
            else
                collection.RemoveAt(collection.Count - 1);
        }
    }
