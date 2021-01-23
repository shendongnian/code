      class MyContext : DbContext
        {
            public DbSet<Order> Orders { get; set; }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.HasSequence<int>("OrderNumbers", schema: "shared")
                    .StartsAt(1000)
                    .IncrementsBy(5);
            }
        }
