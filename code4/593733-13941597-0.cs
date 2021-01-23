    [TestFixture]
    public class ContainsTest
    {
        [Test]
        public void TestFind()
        {
            var customers = new List<Customer>
                                {
                                    new Customer() {FirstName = "Chuck"},
                                    new Customer() {FirstName = Path.GetRandomFileName()},
                                    new Customer() {FirstName = Path.GetRandomFileName()},
                                    new Customer() {FirstName = Path.GetRandomFileName()},
                                    new Customer() {FirstName = Path.GetRandomFileName()},
                                };
            //Get all objects that match
            var findResult = customers.Find(c => c.FirstName =="Chuck");
            var findSingle = customers.Single(c => c.FirstName == "Chuck");
            //Has at least one instance
            customers.Any(c => c.FirstName.Contains("Chuck"));
        }
        public class Customer
        {
            public string FirstName { get; set; }
        }
    }
