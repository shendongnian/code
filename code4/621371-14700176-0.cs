    [XmlRoot("authenticationResponse")] 
    public class AuthenticationResponse 
    { 
        [XmlArrayItem("AccountId")] 
        public List<long> Accounts { get; set; } 
    }
