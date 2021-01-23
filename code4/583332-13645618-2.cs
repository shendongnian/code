    public class YourContext : DbContext
    {
       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
          base.OnModelCreating(modelBuilder);
          modelBuilder.Configurations.Add(new PocoEntityConfiguration());
       }
    }
    
    public class PocoEntityConfiguration : EntityTypeConfiguration<PocoEntity>
    {
       public PocoEntityConfiguration()
       {
          Property(e => e.TheProperty)
             .IsRequired()
             .HasMaxLength(80)
             ...
          ;
       }
    }
