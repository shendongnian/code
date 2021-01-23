    public IQueryable<Customer> FindCustomers(Expression<Func<Customer, Address, bool>> predicate)
    {
    	return DB.Customers.Join(DB.Addresses, c => c.ID, a => d.CustomerID, (c, a) => new { Address = a, Customer = c})
    		.Where(pair => predicate(pair.Customer, pair.Address))
    		.Select(pair => pair.Customer)
    }
