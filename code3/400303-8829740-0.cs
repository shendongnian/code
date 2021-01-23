    IQueryable<CustomerModel> GetCustomers()
    {
        return from c in entities.Customers
               select new CustomerModel {
                   CustomerId = c.CustomerId,
                   CustomerName = c.CustomerName
                   Orders = from o in c.Orders
                            select new Order{
                                OrderId = o.OrderId,
                                ...
                            }
               };
    }
