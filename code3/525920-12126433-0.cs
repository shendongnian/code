    var customers = new List<Customer> { … };
    IQueryable<Customer> results = customers.AsQueryable();
    
    
    if(!string.IsNullOrEmpty(CustomerName))
        results = results.Where(x => x.Name = CustomerName);
    
    if(CustomerMaxAge != 0)
        results = results.Where(x => x.Age <= CustomerMaxAge);
    //etc....
    return results.ToList();
