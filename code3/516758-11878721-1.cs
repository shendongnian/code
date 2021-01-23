    // Create a Customer class.
    public class Customer
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Mobile {get; set;}
        public string Address {get; set;}
        public string Country {get; set;}
    }
    // Create a CustomerRecord class.
    public class CustomerRecord
    {
        public Customer customer {get; set;}
        public int Id {get; set;}
    }
    // Create a collection of CustomerRecords
    public List<CustomerRecord> custRecords {get; set;}
