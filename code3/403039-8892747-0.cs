    public class Employee
    {
        public Employee(Employee manager)
        {
            this.Manager = manager;
        }
        public String StaffID { get; set; }
        public String Forename { get; set; }
        public String Surname { get; set; }
        public Employee Manager { get; set; }
    }
