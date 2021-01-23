    IQueryable<Guid> GetOrdered(IQueryable<Guid> ids, bool descending = false)
    {
        var results = storedIds.Where(somecondition);        
        if (descending)
           results = results.OrderByDescending(o => o.Something);
        else
           results = results.OrderBy(o => o.Something);
        return results.Select(o => o.Id);
    }
