    [DataContract(Name = "Customer")]
    public class Customer
    {
        [DataMember(Name = "FirstName")]
        public string FirstName { get; set; }
        
        [DataMember(Name = "LastName")]
        public string LastName { get; set; }
    }
