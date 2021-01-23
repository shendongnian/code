    public class RequestsContext : DbContext
    {
        public DbSet<EmployeeRequest> EmployeeRequests { get; set; }
        public DbSet<ChangeOrder> ChangeOrders { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    
        public RequestsContext ()
        : base("RequestsContext")
        {}
    
    }
