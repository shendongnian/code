         public static decimal GetCustomerOrderTotalByYear(this IRepository<Customer> repository, string customerId, int year)
        {
            return repository
                .Queryable()
                .Where(c => c.CustomerID == customerId)
                .SelectMany(c => c.Orders.Where(o => o.OrderDate != null && o.OrderDate.Value.Year == year))
                .SelectMany(c => c.OrderDetails)
                .Select(c => c.Quantity*c.UnitPrice)
                .Sum();
        }
 
