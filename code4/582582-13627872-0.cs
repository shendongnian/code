    class User
    {
       public string IPAddress { get; set; }
       public ICollection<Settings> Settings { get; set; }
       public string UserName { get; set; }
    }
    
    class MyContext : DbContext
    {
       public DbSet<User> Users { get; set; }
       public DbSet<Settings> Settings { get; set; }
    }
