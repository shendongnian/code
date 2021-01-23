    public class User
    {
        [XmlElement("FirstName")]
        public Name FirstName { get; set; }
        [XmlElement("LastName")]
        public Name LastName { get; set; }
    }
    public class Name
    {
        [XmlText]
        public string Name { get; set; }
        [XmlAttribute("lastModified")]
        public long Modified { get; set; }
    }
