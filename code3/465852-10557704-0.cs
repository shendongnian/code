    var query = customerList;
    
    if (sortDirection == "ASC")
    {
        if (sortBy == "Id")
           query = query.OrderBy(x => x.Id);
        ///and so on
    }
    
    query = query.Skip(startIndex).Take(pageSize).ToList();
