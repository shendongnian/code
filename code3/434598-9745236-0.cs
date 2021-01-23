    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    ...
    modelBuilder.Configurations.Add(new GroupMap());
    ...
    }
    
    public class GroupMap : EntityTypeConfiguration<Group>
        {
            public GroupMap()
            {
                // Relationships
                this.HasMany(e => e.Reports)
                  .WithMany(set => set.Groups)
                  .Map(mc =>
                  {
                      mc.ToTable("groupreporttablename");
                      mc.MapLeftKey("GroupID");
                      mc.MapRightKey("ReportID");
                  });
            }
        }
