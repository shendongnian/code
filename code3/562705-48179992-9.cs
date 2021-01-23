    public class HomeController : Controller { 
       public void SaveEmployee()
       {
           Employee empl = new Employee();
           empl.FirstName = "John";
           empl.LastName = "Doe";
           empl.EmployeeId = 247854;
    
           Business myBus = new Business();
           myBus.SaveEmployee(empl);
       }
    }
    
    public class Employee { 
     string FirstName { get; set; }
     string LastName { get; set; }
     int EmployeeId { get; set; }
    }
