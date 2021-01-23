    public class Employee
    {
        public int EmployeeNum { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Wage { get; set; }
        public double Hours { get; set; }
        
        public void Employee()
        {
            EmployeeNum = 0;
            Name = "";
            Address = "";
            Wage = 0.0;
            Hours = 0.0;
        }
    }
