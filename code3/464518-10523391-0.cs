    public class MyContext : DbContext
    {
        public DbSet<Payment> Payments{ get; set; }
        public DbSet<Customer> Customers { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payments>()
                        .HasRequired(s => s.Customer)
                        .WillCascadeOnDelete();
        }
    }
