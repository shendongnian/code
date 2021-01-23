    class MyUserContext : DbContext
    {
        public MyUserContext : base("MyConnectionString") // Can be a user context, etc
        {
            System.Data.Entity.Database.SetInitializer(new NoDatabaseInitializer<MyContext>());
        }
    }
