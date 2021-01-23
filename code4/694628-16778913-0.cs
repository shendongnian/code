    public void DoWork(IEnumerable<object> collection)
    {
        var queryable = collection.ToList().AsQueryable();
        int count = 0;
        if (queryable != null)
            count = queryable.Count();
        else
            throw new InvalidOperationException("Not able to get count");
    
        //Some other operations using queryable...
    }
