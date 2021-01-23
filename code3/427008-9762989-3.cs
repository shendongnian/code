    public class EmployeeContext : DbContext
    {
        static EmployeeContext()
        {
            Database.SetInitializer<EmployeeContext>( null ); // must be turned off before mini profiler runs
        }
        public IDbSet<Employee> Employees { get; set; } 
    }
