        class BlogContext : DbContext
        {
    
            public BlogContext()
            {
               System.Data.Entity.Database.SetInitializer(
                 new CreateDatabaseIfNotExists<BlogContext>());
            }
    
            public DbSet<BlogEntry> BlogEntires
            {
                get;
                set;
            }
        }
