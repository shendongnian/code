	public static void Add(DTO.Customer customer)
	{
		MyEntities db = new MyEntities();
		var customerToAdd = new MyEntities.Data.Customer { Address = customer.Address, FirstName = customer.FirstName, LastName = customer.LastName, etc... };
		db.Customers.Add(customerToAdd);
		db.SaveChanges();
		customer.CustomerId = customerToAdd.CustomerId;
	}
