     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
         modelBuilder.Entity<Message>().HasMany<Phone>(m => m.Phones).WithMany(p => p.Messages).Map
               (
                x =>
                   {
                      x.ToTable("MessagePhone", "public");
                   }
               );
     }
