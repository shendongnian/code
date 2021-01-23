    private static IQueryable<Customer> GetQuery2(NorthEntities context) {
        IQueryable<Customer> customers = context.Customers;
        var custParam = Expression.Parameter(typeof(Customer), "c");
        var companyNamePropValue = Expression.Property(custParam, typeof(Customer).GetProperty("CompanyName"));
        var containsParameter = Expression.Constant("z");
        var containsCall = Expression.Call(companyNamePropValue, typeof(string).GetMethod("Contains"), containsParameter);
        var wherePredicate = Expression.Lambda<Func<Customer, bool>>(containsCall, custParam);
        return customers.Where(wherePredicate);
    }
