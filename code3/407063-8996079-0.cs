    public class MyContext : DbContext
    {    
         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Foo>()
               .HasMany(e => e.Bars)
               .WithMany(s => s.Foos)
               .Map(l =>
                 {
                    l.ToTable("FooBar");
                    l.MapLeftKey("FooId");
                    l.MapRightKey("BarId");
                 }
               );
        }
    }
