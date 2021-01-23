    public class Member
    {
        public int ID { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public int age { get; set; }
        public virtual int AddressId { get; set; }
        public virtual AddressInformation Address { get; set; }
        public string EmailAddress { get; set; }
        public string HomePhoneNumber { get; set; }
        public string MobileNumber { get; set; }
    }
    public class AddressInformation
    {
        public int ID { get; set; }
        public string HouseNoName { get; set; }
        public string StreetName { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }
