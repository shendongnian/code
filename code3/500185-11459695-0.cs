    [DataContract]
    public class Employee
    {
        [DataMember]
        public int NTID { get; set; }
    
        [DataMember]
        public string LastName { get; set; }
    
        [DataMember]
        public int FirstName { get; set; }
    }
