    public abstract class ContactManager<T> where T : Contact
    {  
      public abstract List<T> GetContacts(string searchValue);  
    }
    public class EmployeeManager : ContactManager<Employee>
    {  
      public abstract List<Employee> GetContacts(string searchValue);  
    }
