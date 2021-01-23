    var filter = EntityFilter
    .Where(c => c.Name == came)
    .Where(c => c.City == city);
    
    var customers = FindCustomers(filter);
    
    Customer[] FindCustomers(IEntityFilter filter)
    {
    var query = context.Customers;
    query = filter.Filter(query);
    return query.ToArray();
    }
