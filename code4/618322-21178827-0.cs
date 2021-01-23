			public DbSet<UserProfile> Users { get; set; }
	1. Override `OnModelCreating` in your subclass of `DbContext` and call [`DbModelBuilder.Entity`](http://msdn.microsoft.com/en-us/library/gg696542.aspx):
	
			protected override void OnModelCreating(DbModelBuilder modelBuilder)
			{
				base.OnModelCreating(modelBuilder);
				modelBuilder.Entity<UserProfile>();
			}
