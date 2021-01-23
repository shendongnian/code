    DbContext.CustomerProducts.Where(p => p.Customers_Id == customerId)
        .ToList()
        .Distinct(new MyComparer())
        .Select(r => new {
        // etc.
    public class MyComparer : IEqualityComparer<CustomerProduct>
    {
        // implement **Equals** and **GetHashCode** here
    }
