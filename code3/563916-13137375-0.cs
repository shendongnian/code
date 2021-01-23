        public class Customer { public string FirstName; public string LastName;}
        public class CustomerFilter { public Func<Customer, string> Selector; public string Filter;}
        [TestMethod()]
        public void DynamicFilterTest()
        {
            var jonSkeet = new Customer() { FirstName = "Jon", LastName = "Skeet" };
            var joelOnSoftware = new Customer() { FirstName = "Joel", LastName = "OnSoftware" };
            var customers = new List<Customer>() { jonSkeet, joelOnSoftware };
            var searchList = new List<CustomerFilter>();
            searchList.Add(new CustomerFilter() { Selector = c => c.LastName, Filter = "Skeet" });
            searchList.Add(new CustomerFilter() { Selector = c => c.FirstName, Filter = "Jon" });
            var query = customers.AsEnumerable();
            foreach (var kv in searchList)
            {
                query = query.Where(c => kv.Selector.Invoke(c) == kv.Filter);
            }
            var result = query.ToList();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(jonSkeet, result.Single());
        }
