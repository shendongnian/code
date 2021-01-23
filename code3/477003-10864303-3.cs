    public class EmployeeService
    {
         
         public int GetEmployeeCount
         {
                using (NORTHWNDEntities c = new NORTHWNDEntities())
                {
                    var count = c.Employees.Count();                   
                    return count;       
                }
         }
    }
