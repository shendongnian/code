    public partial class EntityContainer : DbContext, IDisposable
    {
        public EntityContainer()
            : base("name=EntityContainer")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<OrderStatusType> OrderStatusTypes { get; set; }
        public DbSet<Person> Persones { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<ItemOrderList> ItemOrderLists { get; set; }
        public DbSet<ItemOrderStatus> ItemOrderStatuses { get; set; }
        public DbSet<PaymentOrderStatus> PaymentOrderStatuses { get; set; }
        public DbSet<Prepaid> Prepaids { get; set; }
        
        public void Dispose()
        {
            base.Dispose();
        }
    }
