    public class User
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int Address1Id { get; set; }
        
        public Address Address { get; set; }
        public Address Address1 { get; set; }
    }
