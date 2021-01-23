        public class UserAccount
        {
            public int UserAccountId {get;set;}
            public int UserId {get;set;}
            public DateTime LastLogin {get;set;}
            public bool IsLocked {get;set;}
            public bool IsActive {get;set;}
            public User User {get;set;}
        }
        
        public class ExternalUserAccount : UserAccount
        {
            public int ExternalAccountId {get;set;}
            public string ProviderName {get;set;}
            public string ProviderUserName {get;set;}
        }
        
        public class SystemUserAccount : UserAccount
        {
            public int SystemUserAccountId {get;set;}
            public string PasswordHash {get;set;}
            public string Token {get;set;}
        }
        
        public class User
        {
            public int UserId {get;set;}
            public string Name {get;set;}
            public string Description {get;set;}
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().ToTable("UserAccounts");
            modelBuilder.Entity<UserAccount>().HasKey(ua => ua.UserAccountId);
            modelBuilder.Entity<UserAccount>().HasRequired(ua => ua.User)
                                              .WithMany()
                                              .HasForeignKey(ua => ua.UserId);
            modelBuilder.Entity<ExternalUserAccount>().ToTable("ExternalUserAccounts");
            modelBuilder.Entity<SystemUserAccount>().ToTable("SystemUserAccounts");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            
        }
