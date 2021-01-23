    var query = Repository.Orders
    // Build where clause
    if (orderNo >0){
        query = query.Where(o => o.OrderNo == orderNo);
    }
    if (firstName.Length > 0){
        query = query.Where(o => o.FirstName == firstName);
    }
    if (lastName.Length > 0){
        query = query.Where(o => o.LastName == lastName);
    }
    // Build OrderBy clause
    query = query.OrderByDescending(o => o.orderNo);
    // Execute Query
    results = query.ToList();
