    Dictionary<int, Employee> employees;
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<int> ChildrenIDs { get; set; }
        public List<Employee> Children { get; set; }
    }
