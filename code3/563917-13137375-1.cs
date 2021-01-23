        public class Customer { public string FirstName; public string LastName;}
        public class CustomerFilter
        {
            public Func<Customer, string> Selector;
            public string Filter;
            public IEnumerable<Customer> Apply(IEnumerable<Customer> values)
            {
                return values.Where(c => this.Selector.Invoke(c) == this.Filter);
            }
        }
        [TestMethod()]
        public void DynamicFilterTest()
        {
            var jonSkeet = new Customer() { FirstName = "Jon", LastName = "Skeet" };
            var joelOnSoftware = new Customer() { FirstName = "Joel", LastName = "OnSoftware" };
            var customers = new List<Customer>() { jonSkeet, joelOnSoftware };
            var jonSkeetFilters = new List<CustomerFilter>() { 
                new CustomerFilter() { Selector = c => c.LastName, Filter = "Skeet" },
                new CustomerFilter() { Selector = c => c.FirstName, Filter = "Jon" }
            };
            var query = customers.AsEnumerable();
            foreach (var filter in jonSkeetFilters)
            {
                query = filter.Apply(query);
            }
            var result = query.ToList();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(jonSkeet, result.Single());
        }
        
