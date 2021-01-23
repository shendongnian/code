	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Sale>().Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		modelBuilder.Entity<Sale>().Property(a => a.TrNo).HasKey(b => b.TrNo);
	}
