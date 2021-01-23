    public class YourContext: DbContext
    {
      public DbSet<Plan> Plans { get; set; }
      public DbSet<Material> Materials { get; set; }
    
      public YourContext()
        : base("YourDb")
      {
      }
    
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
        modelBuilder.Entity<Plan>().
          HasMany(c => c.Material).
          Map(
           m =>
           {
             m.MapLeftKey("MaterialId");
             m.MapRightKey("PlanId");
             m.ToTable("Plans");
           });
      }
    }
