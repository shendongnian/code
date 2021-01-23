    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
    
    public class Company : BaseEntity
    {
        public string Name { get; set; }
    }
    
    internal class BaseEntityMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseEntityMap()
        {
            // Primary Key
            HasKey(t => t.Id);
        }
    }
    
    internal class CompanyMap : BaseEntityMap<Company>
    {
        public CompanyMap()
        {
            // Properties
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
    
    public class AcmeContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CompanyMap());
        }
    }
