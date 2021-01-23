    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
    public class Role
    {
        public int RoleId { get; set; }
        public string Rolename { get; set; }
 
        public virtual ICollection<User> Users { get; set; }
    }
    class ConfigurationContext : DbContext
    {
        public ConfigurationContext()
        {
            Database.SetInitializer<ConfigurationContext>(
                new DropCreateDatabaseIfModelChanges<ConfigurationContext>());
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
