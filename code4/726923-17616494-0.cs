    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    [DataContract]
    public class Customer
    {
        [DataMember] public string FirstName { get; set; }
        [DataMember] public string LastName { get; set; }
    }
