    public IQueryable<Customer> FindCustomers(Expression<Func<Customer, bool>> predicate)
    {
    	return DB.Customers.Join(DB.Addresses, c => c.ID, a => d.CustomerID, (c, a) => c)
    		.Where(predicate)
    }
