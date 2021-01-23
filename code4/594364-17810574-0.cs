    [Serializable]
    public partial class MyDataContext<T> : DbContext where T : class
    {
        static MyDataContext()
        {
            Database.SetInitializer<MyDataContext>(null);
        }
        public MyDataContext()
            : base("name=MyDBString")
        { }
        // Standard table properties...
        public DbSet<T> SettingDefinitions
        {
            get { return this.Set<T>(); }
        }
        // Restricted table methods...
        public DbSet<T> GetClients(
            DatabasePermissions perms = DatabasePermissions.Select)
        {
            // getPermissibleSet is a method in a helper class that does some 
            // magical querying and produces a filtered DbSet.
            return getPermissibleSet<T>(perms);
        }
    }
