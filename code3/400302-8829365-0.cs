    IQueryable<Customer> GetCustomers()
    {
        return entities.Customers;
    }
    IQueryable<Order> GetOrders()
    {
        return entities.Orders;
    }
    IEnumerable<CustomerModel> GetCustomerModels()
    {
        var result = from c in GetCustomers()
                     let orderModels = from o in GetOrders() 
                                       where o.CustomerId == c.CustomerId
                                       select new OrderModel
                                       {....}
                     select new CustomerModel  
                     {
                         CustomerId = c.CustomerId,
                         CustomerName = c.CustomerName,
                         Orders = orderModels.ToArray()
                     }; 
        return result;
    }
