        [TestMethod]
        private void AddCustomer()
        {   //Single Customer
            var customer = new Customer { FirstName = "FitzWilliam", LastName = "Barnabus" };
            using (var context = new SalesContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            //List of Customers (Contain the records you added to the customer objects)
            var customers = new List<Customer>();
            var customer1 = new Customer { FirstName = "Chip", LastName = "TheMan" };
            var customer2 = new Customer { FirstName = "FitzWilliam", LastName = "Barnabus" };
            
            customers.Add(customer1);
            customers.Add(customer2);
            using (var context = new SalesContext())
            {
                foreach (var person in customers)
                {
                    context.Customers.Add(person);
                }
                context.SaveChanges();
            }
        }
