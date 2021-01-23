    public class Customer
    {
        public Contact Contact { get; set; }
        public string Comments { get; set; }
    }
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string CellPhone { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public string Type { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string RegionCode { get; set; }
        public string PostalCode { get; set; }
    }
