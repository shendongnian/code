    public class MyDbContext : DbContext
    {
        public DbSet<AccountTypes> AccountTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTypes>.HasKey(x => x.AccountTypeID);
            base.OnModelCreating(modelBuilder);
        }
    }
