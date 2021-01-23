	var ids = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
	var customers = new  System.Collections.Concurrent.BlockingCollection<Customer>();
	
	RunWithMaxDegreeOfConcurrency(10, ids, async i =>
	{
		ICustomerRepo repo = new CustomerRepo();
		var cust = await repo.GetCustomer(i);
		customers.Add(cust);
	});
	
	foreach ( var customer in customers )
	{
		Console.WriteLine(customer.ID);
	}
