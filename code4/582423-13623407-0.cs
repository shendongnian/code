    IQueryable<Customer> query = db.Customers;
    if(name != null) query = query.Where(x => x.Name == name);
    if(region != null) query = query.Where(x => x.Region == region);
    ...
    if(dob != null) query = query.Where(x => x.DoB == dob);
    var results = query.Take(50).ToList();
