    [DataContract(Namespace="http://example.com/recordservice")]
    public class Appointment
    {
        [DataMember(Order = 1)]
        public int ResponseType { get; set; }
    
        [DataMember(Order = 2)]
        public int ServiceType { get; set; }
    
        [DataMember(Order = 3)]
        public string ContactId { get; set; }
    
        [DataMember(Order = 4)]
        public string Location { get; set; }
    
        [DataMember(Order = 5)]
        public string Time { get; set; }        
    }
