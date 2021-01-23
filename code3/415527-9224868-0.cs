    public class EmployeeRepository : GenericRepository
    {
       public IEnumerable<Employee> GetEmployeesBySearch(string id, string name...)
       {
         return this.Get(x => x.Name == name && ...);
       }
    }
