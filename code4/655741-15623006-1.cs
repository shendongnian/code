    var liteCustomers = context.Customers
                        .Where(c => c.Name.StartsWith("Smith, ")
                        .Select(c => new CustomerLite()
                        {
                            CustomerId = c.CustomerId,
                            Name = c.Name
                        })
                        .ToList();
