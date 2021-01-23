    public class Employee
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlElement("field")]
        public Field[] Fields { get; set; }
    }
    public class Field
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
