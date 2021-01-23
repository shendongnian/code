    public Customer FindByName(string name)
    {
        foreach (var customer in database.Customers)
           if (customer.Name == name)
              return customer;
    }
    public Customer FindByAddress(string address)
    {
        foreach (var customer in database.Customers)
           if (customer.Address == address)
              return customer;
    }
