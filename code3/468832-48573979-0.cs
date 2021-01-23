    public partial class DataDbContext : DbContext
    {
        public DataDbContext()
            : base("name=DefaultConnection")
        {
        }
        static DataDbContext() // This is an enhancement to Roger's answer
        {
            Database.SetInitializer(new DataDbInitializer()); 
            var configuration = new DataDbConfiguration();
            var migrator = new DbMigrator(configuration);
            if (migrator.GetPendingMigrations().Any())
                migrator.Update();
        }
        // DbSet's
        public DbSet<CountryRegion> CountryRegion { get; set; }
        // bla bla bla.....
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            //Configuration.ValidateOnSaveEnabled = false; 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly()); // Discover and apply all EntityTypeConfiguration<TEntity> of this assembly, it will discover (*)
        }
    }
    internal sealed class DataDbInitializer : MigrateDatabaseToLatestVersion<DataDbContext, DataDbConfiguration>
    {
    }
    internal sealed class DataDbConfiguration : DbMigrationsConfiguration<DataDbContext>
    {
        public DataDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        protected override void Seed(DataDbContext context)
        {
            DataSeedInitializer.Seed(context); 
            base.Seed(context);
        }
    }
    internal static class DataSeedInitializer
    {
        public static void Seed(DataDbContext context)
        {
            SeedCountryRegion.Seed(context);
            // bla bla bla.....
            context.SaveChanges();
        }
    }
    internal static class SeedCountryRegion
    {
        public static void Seed(DataDbContext context)
        {
            context.CountryRegion.AddOrUpdate(countryRegion => countryRegion.Id,
                new CountryRegion { Id = "AF", Name = "Afghanistan" },
                new CountryRegion { Id = "AL", Name = "Albania" },
                // bla bla bla.....
                new CountryRegion { Id = "ZW", Name = "Zimbabwe" });
            context.SaveChanges();
        }
    }
    public class CountryRegionConfiguration : EntityTypeConfiguration<CountryRegion> // (*) Discovered by
    {
        public CountryRegionConfiguration()
        {
            Property(e => e.Id)
                .IsRequired()
                .HasMaxLength(3);
            Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
    public partial class CountryRegion : IEntity<string>
    {
        // Primary key 
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public abstract class Entity<T> : IEntity<T>
    {
        //Primary key
        public abstract T Id { get; set; }
    }
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
