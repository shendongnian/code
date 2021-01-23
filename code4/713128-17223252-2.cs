    public class User
    {
        public string Username {get;set;}
        public string Password {get;set;}
    }
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users {get;set;}
    }
