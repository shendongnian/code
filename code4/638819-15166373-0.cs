    public class Employee
    {
        public Employee()
        {
            Subordinates = new List<Employee>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int SupervisorId { get; set; }
        public List<Employee> Subordinates { get; private set; }
        public XElement ToXml()
        {
            return new XElement("Employee",
                       new XElement("Id", Id),
                       new XElement("Name", Name),
                       new XElement("Subordinates", Subordinates.Select(s => s.ToXml())));
        }
    }
