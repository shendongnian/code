    [DataContract]
    [Route("/SendGetAccountNotification")]
    public class SendGetAccountNotification
    {
        [DataMember]
        public Account Account { get; set; }
        [DataMember]
        public string ExternalAccountID { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
