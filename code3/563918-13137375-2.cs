        public class Customer { public string FirstName; public string LastName;}
        public class Filter<T>
        {
            public Func<T, string> Selector;
            public string Value;
            public IEnumerable<T> Apply(IEnumerable<T> values)
            {
                return values.Where(c => this.Selector.Invoke(c) == this.Value);
            }
        }
        [TestMethod()]
        public void DynamicFilterTest()
        {
            var jonSkeet = new Customer() { FirstName = "Jon", LastName = "Skeet" };
            var joelOnSoftware = new Customer() { FirstName = "Joel", LastName = "OnSoftware" };
            var customers = new List<Customer>() { jonSkeet, joelOnSoftware };
            var jonSkeetFilters = new List<Filter<Customer>>() { 
                new Filter<Customer>() { Selector = c => c.LastName, Value = "Skeet" },
                new Filter<Customer>() { Selector = c => c.FirstName, Value = "Jon" }
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
