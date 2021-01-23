    public class Employee
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlElement("field")]
        public string DisplayName { get; set; }
    }
