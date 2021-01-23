    IEnumerable<Customer> customers = from c in context.Customers 
        select new
        {
            ID = c.ID,
            Name = c.Name,
            LastName = c.LastName,
            DepID = c.DepID
        }
        .AsEnumerable()
        .Select(d=>new Customer
        {
            ID = c.ID,
            Name = c.Name,
            LastName = c.LastName,
            DepID = c.DepID,
            Editable = SomeStruct.Check(c.DepID)
        });
