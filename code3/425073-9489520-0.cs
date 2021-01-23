    public class Company
    {
       public int ID { get; set; }
       public string Name { get; set; }
    
       public IEnumerable<Department> GetDepartments()
       {
          // Get departments here
       }
    }
    
    public class Department
    {
       public int ID { get; set; }
       public string Name { get; set; }
       protected int CompanyID { get; set; }
    
       private Company _Company;
       public Company Company
       {
          get
          {
             // Get company here
          } 
       }
    
       public IEnumberable<Employee> GetEmployees()
       {
          // Get employees here
       }
    }
    
    public class Employee
    {
       public int ID { get; set; }
       public string Name { get; set; }
       protected int DepartmentID { get; set; }
    
       private Department _Department;
       public Department Department
       {
          get
          {
             // Get department here
          } 
       }
    
       public IEnumberable<Employee> GetEmployees()
       {
          // Get employees here
       }
    }
