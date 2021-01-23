    [XmlRoot("EmployeeConfiguration")]
    public class EmployeeConfiguration
    {
        [XmlArray("Bosses")]
        [XmlArrayItem("Boss")]
        public List<Boss> Bosses { get; set; }
    }
    public class Boss
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlArray("Employees")]
        [XmlArrayItem("Employee")]
        public List<Employee> Employees { get; set; }
    }
    public class Employee
    {
        [XmlAttribute]
        public string Id { get; set; }
    }
