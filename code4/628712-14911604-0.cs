    public partial class oraDbContext : DbContext
    {
        static oraDbContext() {
            Database.SetInitializer<oraDbContext>(null);
        }
    
        public oraDbContext(string connName)
            : base("Name=" + connName) { }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            schema1(modelBuilder);
            schema2(modelBuilder);
        }
    }
	
	public partial class oraDbContext : DbContext
	{
	    public DbSet<someTable> someTable { get; set; }
		void schema1(DbModelBuilder modelBuilder)
		{
		    modelBuilder.Configurations.Add(new someTableMap());
		}
	}
