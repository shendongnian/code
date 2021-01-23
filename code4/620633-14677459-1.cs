    public class GenericEntities : DbContext, IRepository 
    {
        //...
        private string TablePrefix { get; set; }
        public GenericEntities(string tablePrefix)
        {
            this.TablePrefix = tablePrefix;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public override OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>.ToTable(TablePrefix + "_product");
            modelBuilder.Entity<Customer>.ToTable(TablePrefix + "_customer");
        }
    }
