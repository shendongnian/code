    // Reader
    public IList<ZGpCustomer> GetCustomers()
    {
        return _customers.AsReadOnly();
    }
