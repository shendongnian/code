    public IDbSet<AnnualPeriod> AnnualPeriods { get; set; }
    void OnModelCreating(DbModelBuilder modelBuilder){
       ....
       //I was missing this line
       modelBuilder.Configurations.Add(new AnnualPeriodMap ());
