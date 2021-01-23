    public class AccountsContext : DbContext
    {
        public AccountsContext()
            : base("name=ConnectionStringNameHere")
        {
            Database.SetInitializer(null);
        }
        public DbSet<UserProfile> User { get; set; }
        ...
    }
