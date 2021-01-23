    public DbSet<WeeklyPayPeriod> WeeklyPayPeriods { get; set; }
    public DbSet<MnthlyPayPeriod> MonthlyPayPeriods { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
			modelBuilder.Entity<WeeklyPayPeriod>().Map(m =>
				                                           {
					                                           m.MapInheritedProperties();
															   m.ToTable("AvailPayPeriodsWeekly");
				                                           });
			modelBuilder.Entity<MonthlyPayPeriod>().Map(m =>
				                                           {
					                                           m.MapInheritedProperties();
															   m.ToTable("AvailPayPeriodsMonthly");
				                                           });
    }
