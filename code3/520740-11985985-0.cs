    [XmlRoot("abc")]
    public class Entity
    {
        [XmlElement("xyz")]
        public SubEntity SubEntity { get; set; }
    }
    
    public class SubEntity
    {
        [XmlElement("code")]
        public string Code { get; set; }
        [XmlElement("message")]
        public string Message { get; set; }
    }
