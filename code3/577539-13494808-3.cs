    [XmlRoot("Employee"), Serializable]
    public class Employee
    {
        [XmlAnyElement]
        public XmlElement [] EmployeeDetails { get; set; }
        [XmlElement("Transcation")]
        public List<Transaction> Transcations { get; set; }
    }
