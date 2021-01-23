    public DbSet<PayPeriod> WeeklyPayPeriods { get; set; }
    public DbSet<MnthlyPayPeriod> MonthlyPayPeriods { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         modelBuilder.Configurations.Add(new WeeklyPayPeriodConfiguration());
         modelBuilder.Configurations.Add(new MonthlyPayPeriodConfiguration());
    }
