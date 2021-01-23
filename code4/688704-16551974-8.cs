    public class ExampleContext : DbContext
    {
        public ExampleContext()
			: base("Name=ExampleContext") {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                    .HasOptional(m => m.Location)
                    .WithRequired();
        }
    }
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public int EmployeeId { get; set; }
        
        public virtual Location Location { get; set; }
    }
    
    public class Location
    {
        [Key]
        [Column("employee_id")]
        public int EmployeeId { get; set; }
    }
