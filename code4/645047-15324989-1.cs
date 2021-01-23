        public List<Customer> MyCustomers { get; set; }
       
        public void GetCustomers()
        {
            using(var context = new SalesContext())
	        {
		        var customers = from b in context.Customers
                                select b;
                MyCustomers = customers.ToList<Customer>();
	        }
        }
        public void MethodThatChangesCustomers()
        {
            
        }
        public void UpdateDatabase()
        {
            using(var context = new SalesContext())
	        {
		        foreach (var person in MyCustomers)
	            {
		            context.Customers.Add(person);
	            }
                context.SaveChanges();
	        }
        }
