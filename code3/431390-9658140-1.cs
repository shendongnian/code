    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> employees { get; set; }
    
        public Department()
        {
            employees = new List<Employee> ();
        }
    }
