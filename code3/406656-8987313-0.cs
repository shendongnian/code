    public abstract class ContactManager<TContactType> 
        where TContactType : Contact 
    {
        public abstract List<TContactType> GetContacts(string searchValue);  
    }
    public abstract class EmployeeManager : ContactManager<Employee> 
    {
        ...
    }
