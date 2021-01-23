    var paramExpr = Expression.Parameter(typeof(Invoice), "i");
    var propertyEx = Expression.Property(paramExpr, "Customer");
    
    var body = Expression.Invoke(GetCustomerContactFromCustomer(), propertyEx);
    
    return Expression.Lambda<Func<Invoice, CustomerContact>>(body, paramExpr);
