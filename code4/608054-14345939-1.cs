        [DataContract]
        public class MessageHeader
        {
            [DataMember]
            public string MessageThreadId { get; set; }
            [DataMember]
            public string MessageId { get; set; }
            [DataMember]
            public MessageSender sender { get; set; }
        }
        [DataContract]
        public class MessageSender
        {
            [DataMember]
            public string PartyId { get; set; }
        }
