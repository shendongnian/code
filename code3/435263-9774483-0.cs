    [XmlRoot("Package")]
    public class Package
    {
        public Package() { }
        public Package(MessageTypeRequest req)
        {
            Message = new message();
            Message.requestMessage = req;
        }
        public Package(MessageTypeResponse resp)
        {
            Message = new message();
            Message.responseMessage = resp;
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
            [XmlElement("MessageTypeRequest")]
            public MessageTypeRequest requestMessage { get; set; }
            [XmlElement("MessageTypeResponse")]
            public MessageTypeResponse responseMessage { get; set; }
        }
    }
    public class MessageTypeRequest : Package
    {
        public MessageTypeRequest()
        {
            etc1 = "A simple request.";
            etc2 = "test 2";
        }
        [XmlElement("etc1")]
        public string etc1 { get; set; }
        [XmlElement("etc2")]
        public string etc2 { get; set; }
    }
    public class MessageTypeResponse : Package
    {
        public MessageTypeResponse()
        {
            etc1 = "My simple response";
            etc2 = "test 2";
        }
        [XmlElement("etc1")]
        public string etc1 { get; set; }
        [XmlElement("etc2")]
        public string etc2 { get; set; }
    }
