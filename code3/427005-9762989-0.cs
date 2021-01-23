    public class EmployeeContext : DbContext
    {
        static EmployeeContext()
        {
            Database.SetInitializer<EmployeeContext>( null );
        }
        public IDbSet<Employee> Employees { get; set; } 
    }
