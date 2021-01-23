    public int Enumerable.Count<TSource>(TSource source)
    {
        var collection = source as ICollection
        if (collection != null)
        {
            return collection.Count;
        }
    }
