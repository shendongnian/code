    public class AccountingContext : DbContext, IDisposable
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Payment>()
                    .HasRequired(s => s.Customer)
                    .WithMany()
                    .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }
    }
