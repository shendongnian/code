    class BlogContext : DbContext
    {
            public DbSet<BlogEntry> BlogEntires
            {
                get;
                set;
            }
    }
