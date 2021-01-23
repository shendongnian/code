    var IEnumerable<ListItemType> query = sourceList;
    
    if(queryStringValue != "All")
    {
        var ids = queryStringValue.Split(new[] { ',' })
                                  .Select(x => int.Parse(x)) // remove that line id item.Id is a string
                                  .ToArray();
        query = query.Where(item => ids.Contains(item.Id));
    }
    
    from l in query
        // other conditions
    select new {...}
