    var liteCustomers = (from c in context.Customers
                         where c.Name.StartsWith("Smith, ")
                         select new CustomerLite()
                         {
                             CustomerId = c.CustomerId,
                             Name = c.Name
                         }).ToList();
