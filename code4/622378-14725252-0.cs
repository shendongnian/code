    public Response PostSearchSpecification(SearchSpecification spec)
    {
        int id = _searches.Max(x => x.Key) + 1; // Make thread-safe
        _searches[id] = _provider.GetSome().GetEnumerator();
        return ...;
    }
    
    public Item GetNextResult(int searchSpecId)
    {
        if(_searches[searchSpecId].MoveNext())
            return _searches.Current;
        else
            return null; // or return a HTTP status code that tells the
                         // client that there are no more items.
    }
