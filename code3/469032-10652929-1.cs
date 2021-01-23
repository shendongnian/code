    public int Enumerable.Count<TSource>(IEnumerable<TSource> source)
    {
        var collection = source as ICollection
        if (collection != null)
        {
            return collection.Count;
        }
    }
