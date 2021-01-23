     public DbSet<SystemUser> SystemUser { get; set; }
        public DbSet<SystemUserAccount> SystemUserAccount { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountRole> AccountRole { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemUserAccount>()
                .HasKey(sua => new { sua.UserId, sua.AccountId });
            modelBuilder.Entity<SystemUserAccount>()
                .HasRequired(sua => sua.SystemUser)
                .WithMany(u => u.SystemUserAccounts)
                .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<SystemUserAccount>()
                .HasMany(sua => sua.AccountRoles)
                .WithMany(ar => ar.UserAccounts)
                .Map(m =>
                         {
                             m.ToTable("UserAccountRole");
                             m.MapLeftKey("UserId", "AccountId");
                             m.MapRightKey("AccountRoleId");
                         }
                );
        }
