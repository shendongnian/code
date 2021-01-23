    public class Employee
    {
    
       public int EmployeeID {get;set;}
       public string EmployeeName {get;set;}
       public int CostCenter {get;set;}
       public DateTime StartDate {get;set;}
    
       public Employee(int employeeID)
       {
           //Initialize values
       }
       
       //Also include a parameter-less construct like below
       public Employee()
       {
       }
    
    
    }
