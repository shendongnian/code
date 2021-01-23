    using (var reader = cmd.ExecuteReader())
    {
        List<Customer> customers = new List<Customer>();
        while(reader.Read())
        {
            customers.Add(new Customer
            {
                Name = reader.GetString(0),
                Cash = reader.GetDouble(1)
            });
        }
        return customers;
    }
