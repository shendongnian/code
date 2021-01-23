		Public class MVCRepositoryContext : DbContext 
		{
			static MVCRepositoryContext()
			{
				Database.SetInitializer < mvcrepositorycontext > (null);
			}
			public MVCRepositoryContext():base("MVCRepositoryContext"){	}
			public virtual DbSet<customer> Customers { get; set; }
			public virtual DbSet<book> Books { get; set; }
			public virtual DbSet<author> Authors { get; set; }
		}
