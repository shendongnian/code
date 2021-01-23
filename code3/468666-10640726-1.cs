    var customers1 = dataContext1.Customers.Select(c => new UnifiedCustomer
    {
        CustomerId = c.CustomerId,
        Name = c.CustomerName,
        Field1 = c.Field1,
        Field2 = c.Field2
    });
    var cusomers2 = dataContext2.Customers.Select(c => new UnifiedCustomer
    {
        CustomerId = c.CustomerId,
        Name = c.CustomerName,
        DifferentField1 = c.DifferentField1,
        DifferentField2 = c.DifferentField2
    });
