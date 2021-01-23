    [DataContract(Name = "KPCServer.LogonResult", Namespace="")]
    public class LogonResult
    {
        [DataMember]
        public User User { get; set; }
        [DataMember]
        public bool NewUser { get; set; }
        [DataMember]
        public string Ticket { get; set; }
    }
