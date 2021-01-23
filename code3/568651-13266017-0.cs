    public class Address
    {
        public int AddressId { get; set; }
        public string AddressString { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
    public class House
    {
        public int HouseId { get; set; }
        public virtual Address Address { get; set; }
    }
    public class TestContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<House> Houses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Addresses).WithMany();
            modelBuilder.Entity<House>().HasRequired(h => h.Address).WithOptional().Map(m => m.MapKey("AddressId"));
        }
    }
