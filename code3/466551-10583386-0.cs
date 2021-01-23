    public static bool AtLeast<T>(this IEnumerable<T> source, int count)
    {
        // Optimization for ICollection<T>
        var genericCollection = source as ICollection<T>;
        if (genericCollection != null)
            return genericCollection.Count >= count;
        // Optimization for ICollection
        var collection = source as ICollection;
        if (collection != null)
            return collection.Count >= count;
        // General case
        using (var en = source.GetEnumerator())
        {
            int n = 0;
            while (n < count && en.MoveNext()) n++;
            return n == count;
        }
    }
