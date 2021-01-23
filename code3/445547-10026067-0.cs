    bool onlyForReturningCustomers;
    .....            
    // Make a positively-named variable
    bool includeAllCustomers = !onlyForReturningCustomers;
    var q = context.Products.Where(product => product.StartTime >= fromDate 
                                           && product.StartTime < toDate
                                           && (includeAllCustomers 
                                               || product.IsReturningClient));
    
    return q;
