    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public string Street { get; set; }
        public DateTime LastUpdated { get; set; }
        [IgnoreUtcConversion]
        public Customer Customer { get; set; }
    }
