    public class Company
    {
         public int ID { get; set; }
         public string Name { get; set; }
         public IList<Department> Departments { get; set; }
    }
    
    public class Department
    {
         public int ID { get; set; }
         public string Name { get; set; }
         public Company Company { get; set; }
         public IList<Employee> Employees { get; set; }
    }
    
    public class Employee
    {
         public int ID { get; set; }
         public string FirstName { get; set;}
         public string LastName { get; set; }
         public Department Department { get; set; }
    }
