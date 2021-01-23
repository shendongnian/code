    public void Do<T>(IList<T> collection)
    {
        DoInternal(collection, collection.Count, i => collection[i]);
    }
    public void Do<T>(IReadOnlyList<T> collection)
    {
        DoInternal(collection, collection.Count, i => collection[i]);
    }
    
    private void DoInternal(dynamic collection, int count, Func<int, T> indexer)
    {
        // Get the count.
        int count = collection.Count;
    }
