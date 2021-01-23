    public class EFDbContext : DbContext
        {
            ...
    
            public EFDbContext()
            {
                 Database.Connection.ConnectionString =
                    @"Data Source=.\; Initial Catalog=DbName; Persist Security Info=True; User ID=Username; Password=pass";
            }
        }
