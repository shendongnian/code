    public class TEST
    {
        public Int16 ID { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TEST>().HasKey(a => new { a.ID});
        modelBuilder.Entity<TEST>()
        .Property(p => p.ID)
        .HasColumnType("SMALLINT");
        base.OnModelCreating(modelBuilder);
    }
