    public class EmployeeRepository : GenericRepository<Employee>
    {
       public IEnumerable<Employee> GetEmployeesBySearch(string id, string name...)
       {
         return this.Get(x => x.Name == name && ...);
       }
    }
