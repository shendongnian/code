    public List<CustomerMinInfo> GetAllCust()
    {
        var results = db.Customers.Select(x => new CustomerMinInfo()
        {
            Name = x.CustName,
            Email = x.Email,
            Address = x.Address,
            ContactNumber = x.CustContactNo
        })
        .ToList();
        return results;
    }
