    public partial class UtilityContext : DbContext
    {
        static UtilityContext()
        {
            Database.SetInitializer<UtilityContext>(null);
        }
        public UtilityContext()
            : base("Data Source=SERVER;Initial Catalog=TABLE;Persist Security Info=True;User ID=USERNAME;Password=PASSWORD;MultipleActiveResultSets=True")
        {
        }
        // DbSet, OnModelCreating, etc...
    }
