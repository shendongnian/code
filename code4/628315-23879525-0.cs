    //Error with DbSet<PayPeriod> defined twice    
    public DbSet<PayPeriod> WeeklyPayPeriods { get; set; }
    public DbSet<PayPeriod> MonthlyPayPeriods { get; set; }
    
    //EF can resolve to each  DbSet, but can't store the baseclass PayPeriods
    public DbSet<WeeklyPayPeriod> WeeklyPayPeriods { get; set; }
    public DbSet<MnthlyPayPeriod> MonthlyPayPeriods { get; set; }
