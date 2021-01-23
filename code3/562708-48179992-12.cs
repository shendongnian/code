    Interface IPerson { 
     string FirstName { get; set; }
     string LastName { get; set; }
     int EmployeeId { get; set; }
    }
    
    public class Employee : IPerson {
      int EmployeeId;
    }
    
    public class Admin : IPerson {
      int AdminId;
    }
    
    public class PersistPeople {
       IPerson person;
       // Constructor
       PersistPeople(IPerson person) {
          this.person = person;
       }
       public void SavePerson() {
          person.Save();
       }    
    }
    
    // Now our HomeController is using dependency inversion:
    public class HomeController : Controller { 
    
       // If we want to save an employee we can use Persist class:
       Employee empl = new Employee();
       empl.FirstName = "John";
       empl.LastName = "Doe";
       empl.EmployeeId = 247854;
       PersistPeople persist = new Persist(empl);
       persist.SavePerson();
    
       // Or if we want to save an admin we can use Persist class:
       Admin admin = new Admin();
       admin.FirstName = "David";
       admin.LastName = "Borax";
       admin.EmployeeId = 999888;
       PersistPeople persist = new Persist(admin);
       persist.SavePerson();
       } 
    }
