    public IEnumerable<Customer> GetAllCustomers()
    {
        return
            from row in GetAllData().Rows
            select new Customer
            {
                CustomerId = row.Field<string>("CustomerId"),
                FirstName = row.Field<string>("FirstName"),
                LastName = row.Field<string>("LastName"),
            };
    }
