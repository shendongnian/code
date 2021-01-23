    public static IEnumerable<IList<T>> ToBuckets(this IEnumerable<T> source, int size)
    {
        var bucket = new List<T>(size);
        foreach (var item in source)
        {
            bucket.Add(item);
            if (bucket.Count == size) {
               yield return bucket;
               bucket = new List<T>(size); // or you can use the same one if you're careful
        }
    
        if (bucket.Count > 0) yield return bucket;
    }
