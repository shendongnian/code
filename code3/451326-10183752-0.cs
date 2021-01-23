    public class Employee
    {   
        public Employee()
            : this(0, "", "", 0)
        {
        }
    
        public Employee(int employeeId, string firstName,
                               string lastName, decimal yearSalary) 
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            YearSalary = yearSalary;
        }
    
        public int EmployeeId  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public decimal YearSalary { get; set; }
    }
