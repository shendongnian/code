        List<Employee> Employees = new List<Employee>();
        Employees.Add(new Employee { FirstName = "firstname", LastName = "lastname", isActive = true });
        List<Employee> EmployeesCopy = Employees.Select(x => new Employee(x)).ToList();
        public class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool isActive { get; set; }
            public Employee()
            { }
            public Employee(Employee e)
            {
                FirstName = e.FirstName;
                LastName = e.LastName;
                isActive = e.isActive;
            }
        }
