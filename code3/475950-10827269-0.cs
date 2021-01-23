    public IEnumerable<Customer> GetAllCustomers()
    {
        foreach (DataRow row in GetAllData().Rows)
        {
            yield return new Customer
            {
                CustomerId = row.Field<string>("CustomerId"),
                FirstName = row.Field<string>("FirstName"),
                LastName = row.Field<string>("LastName"),
            };
        }
    }
