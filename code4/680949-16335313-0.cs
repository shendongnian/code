    [XmlRoot("response")]
    public class Response
    {
        [XmlAttribute("code")]
        public string Code { get; set; }
    
        [XmlAttribute("message")]
        public string Message { get; set; }
    }
