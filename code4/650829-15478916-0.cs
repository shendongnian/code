    var query = container.people;
    
    if (contains)
    {
        query = query.Where(p => p.Name.Contains(filter);
    }
    else
    {
        query = query.Where(p => p.Name.StartsWith(filter);
    }
