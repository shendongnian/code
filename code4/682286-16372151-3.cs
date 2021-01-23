    public class Employees
    {
        public List<Employee> Workers { get; set; }
        public Employees()
        {
            this.Workers = new List<Employee>();
        }
    }
    public class Employee
    {
        public Int32 ID{ get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public float Salary{ get; set; }
        public Employee() { }
        public Employee(Int32 id, string fname, string lname, float salary)
        {
            this.ID = id;
            this.FirstName = fname;
            this.LastName = lname;
            this.Salary = salary;
        }
    }
