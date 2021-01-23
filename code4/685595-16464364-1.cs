    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual Employee Manager { get; set; }
    }
