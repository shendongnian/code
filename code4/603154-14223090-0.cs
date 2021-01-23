    public class AddressType
    {
        public int AddressTypeID { get; set; }
        public string Name { get; set; }
        // public ICollection<Person2Address> Person2Addresses { get; set; }
        // optionally you can include this collection or not
    }
    public class Address
    {
        public int AddressID { get; set; }
        public int StateID { get; set; }
 
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public State State { get; set; }
        public ICollection<Person2Address> Person2Addresses { get; set; }
    }
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public ICollection<Person2Address> Person2Addresses { get; set; }
    }
    public class Person2Address
    {
        public int PersonID { get; set; }
        public int AddressID { get; set; }
        public int AddressTypeID { get; set; }
        public Person Person { get; set; }
        public Address Address { get; set; }
        public AddressType AddressType { get; set; }
    }
