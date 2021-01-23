    [XmlRoot("request")]
    public class Request
    {
        [XmlElement("employee")]
        public string Employee { get; set; }
    }
    
    [XmlRoot("employee")]
    public class Employee
    {
        [XmlAttribute("id")]
        public string EmployeeId { get; set; }
    }
