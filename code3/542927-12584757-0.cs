    public class MyContext : DbContext
    {
        public DbSet<Doo> Doos { get; set; }
        public DbSet<Foo> Foos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DooConfiguration());
            modelBuilder.Configurations.Add(new FooConfiguration());
        }
    }
    internal class DooConfiguration : EntityTypeConfiguration<Doo>
    {
        public DooConfiguration()
        {
            // your other property mappings here
            HasMany(m => m.Foo)
            .WithMany(m => m.Doo)
            .Map(m => { 
                m.MapLeftKey("fooID"); 
                m.MapRightKey("dooID"); 
                m.ToTable("ManyToManyTableName"); 
            });
        }
    }
    internal class FooConfiguration : EntityTypeConfiguration<Foo>
    {
        public FooConfiguration()
        {
            // your other property mappings here
            HasMany(m => m.Doo)
            .WithMany(m => m.Foo)
            .Map(m => { 
                m.MapLeftKey("dooID"); 
                m.MapRightKey("fooID"); 
                m.ToTable("ManyToManyTableName"); 
            });
        }
    }
