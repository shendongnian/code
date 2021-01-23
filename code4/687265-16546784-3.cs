    [DataContract]
    public class SendGetAccountNotificationResponse : IHasResponseStatus
    {
        [DataMember]
        public String Result { get; set; }
        [DataMember]
        public ResponseStatus ResponseStatus { get; set; }
    }
