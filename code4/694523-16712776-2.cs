    public class SurveyContext: DbContext
    {
        public SurveyContext() : base("name=ApplicationConnection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Optional
            modelBuilder.Configurations.Add(new Confuration1());
            modelBuilder.Configurations.Add(new Confuration2());
            modelBuilder.Configurations.Add(new Confuration3());
            modelBuilder.Configurations.Add(new GroupConfiguration());
    
            base.OnModelCreating(modelBuilder);
        }
    
        public DbSet<Group> Groups { get; set; }
        public DbSet<Foo> Foos { get; set; }
        public DbSet<Bar> Bars { get; set; }
    }
