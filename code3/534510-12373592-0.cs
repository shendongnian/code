        [DataContract]
    public class SLEmailMessage
    {
        [DataMember]
        public string To { get; set; }
        [DataMember]
        public string From { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Body { get; set; }
        [DataMember]
        public string CC { get; set; }
        [DataMember]
        public string Bcc { get; set; }
        [DataMember]
        public string Attachment { get; set; }
        
    }
