    var query = container.people.AsQueryable();
    
    if (contains)
    {
        query = query.Where(p => p.Name.Contains(filter));
    }
    else
    {
        query = query.Where(p => p.Name.StartsWith(filter));
    }
