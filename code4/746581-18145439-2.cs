    [DataContract]
    public class UserCriteria
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        // add a property for each search criteria....
    }
