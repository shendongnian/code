    public static IEnumerable<int> Indexes<T>(IEnumerable<T> source, T itemToFind)
    {
        if (source == null)
            throw new ArgumentNullException("source");
    
        int i = 0;
        foreach (T item in source)
        {
            if (object.Equals(itemToFind, item))
            {
                yield return i;
            }
    
            i++;
        }
    }
