    public class Customer
    {
        public int CustomerId { get; set; }
    }
    
    public class OtherCustomer
    {
        public int Id { get; set; }
    }
    var customers = new List<Customer>()
    {
        new Customer() { CustomerId = 1 },
        new Customer() { CustomerId = 2 }
    };
    
    var others = new List<OtherCustomer>()
    {
        new OtherCustomer() { Id = 2 },
        new OtherCustomer() { Id = 3 }
    };
    
    var result = customers.WhereValueDoesntMatch(customer => customer.CustomerId, others, other => other.Id).ToList();
    
    Debug.Assert(result.Count == 1);
    Debug.Assert(result[0].CustomerId == 1);
