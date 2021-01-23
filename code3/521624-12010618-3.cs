    public class Model : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOptional(u => u.UserAccount)
                .WithRequired(ua => ua.User);
            modelBuilder.Entity<UserAccount>()
                .HasKey(k => new {k.AccountId, k.UserId});
            modelBuilder.Entity<UserAccount>()
                .HasMany(ua => ua.AccountRoles)
                .WithMany(ar => ar.UserAccounts)
                .Map(map =>
                    {
                        map.ToTable("UserAccountRole");
                        map.MapLeftKey("UserId", "AccountId");
                        map.MapRightKey("AccountRoleId");
                    });
        }
    }
