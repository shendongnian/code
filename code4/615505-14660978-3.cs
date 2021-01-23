    public class MainHierarchyLevelConfiguration : EntityTypeConfiguration<MainHierarchyLevel>
    {
        public MainHierarchyLevelConfiguration()
        {
            Map(mb =>
            {
                mb.MapInheritedProperties();
                mb.ToTable("MainHierarchyLevels");
            });
        }
    }
    public class MainHierarchyItemsConfiguration : EntityTypeConfiguration<MainHierarchyItem>
    {
        public MainHierarchyItemsConfiguration()
        {
            Map(mb =>
            {
                mb.MapInheritedProperties();
                mb.ToTable("MainHierarchyItems");
            });
            HasKey(hierarchyItem => hierarchyItem.Id);
            HasRequired(hierarchyItem => hierarchyItem.Level).WithMany().Map(e => e.MapKey("Level_Id"));
        }
    }
    public class HierarchyContext : DbContext
    {
        public DbSet<MainHierarchyLevel> MainHierarchyLevels { get; set; }
        public DbSet<MainHierarchyItem> MainHierarchyItems { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new MainHierarchyLevelConfiguration());
            modelBuilder.Configurations.Add(new MainHierarchyItemsConfiguration());
        }
    }
