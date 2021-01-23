    [XmlRoot("Package")]
    public class Package
    {
        public Package() { }
        public Package(MessageContent messageContent)
        {
            Message = new message();
            Message.messageContent = messageContent;
        }
        [XmlElement("Parameters")]
        public parameters Parameters;
        public class parameters
        {
            [XmlElement("MessageType")]
            public string MessageType { get; set; }
            [XmlElement("CreationDateTime")]
            public string CreationDateTime { get; set; }
        }
        [XmlElement("Message")]
        public message Message;
        public class message
        {
            [XmlElement(Type = typeof(MessageTypeRequest)), XmlElement(Type = typeof(MessageTypeResponse))]
            public MessageContent messageContent { get; set; }
        }
    }
    public class MessageContent { }
    public class MessageTypeRequest : MessageContent
    {
        public MessageTypeRequest()
        {
            etc1 = "A simple request.";
            etc2 = "test 2";
        }
        public static Package MessageRequest()
        {
            return new Package(new MessageTypeRequest());
        }
        [XmlElement("etc1")]
        public string etc1 { get; set; }
        [XmlElement("etc2")]
        public string etc2 { get; set; }
    }
    public class MessageTypeResponse : MessageContent
    {
        public MessageTypeResponse()
        {
            etc1 = "My simple response";
            etc2 = "test 2";
        }
        public static Package MessageRequest()
        {
            return new Package(new MessageTypeResponse());
        }
        [XmlElement("etc1")]
        public string etc1 { get; set; }
        [XmlElement("etc2")]
        public string etc2 { get; set; }
    }
