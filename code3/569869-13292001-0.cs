    public static IEnumerable<int> Indexes<T>(IEnumerable<T> source, T itemToFind)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (itemToFind == null)
            throw new ArgumentNullException("itemToFind");
    
        int i = 0;
        foreach (T item in source)
        {
            if (itemToFind.Equals(itemToFind))
            {
                yield return i;
            }
    
            i++;
        }
    }
