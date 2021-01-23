      class MyContext : DbContext
        {
            public DbSet<Order> Orders { get; set; }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.HasSequence<int>("OrderNumbers", schema: "shared")
                    .StartsAt(1000)
                    .IncrementsBy(5);
                //Once a sequence is introduced, you can use it to generate values for properties in your model. For example, you can use Default Values to insert the next value from the sequence.
                modelBuilder.Entity<Order>()
                    .Property(o => o.OrderNo)
                    .HasDefaultValueSql("NEXT VALUE FOR shared.OrderNumbers");
            }
        }
