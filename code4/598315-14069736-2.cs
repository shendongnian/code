    [XmlRoot("request")]
    public class Request
    {
        [XmlElement("employee")]
        public Employee Employee { get; set; }
    }
    [XmlRoot("employee")]
    public class Employee
    {
        [XmlText]
        public string Name { get; set; }
        [XmlAttribute("id")]
        public string EmployeeId { get; set; }
    }
