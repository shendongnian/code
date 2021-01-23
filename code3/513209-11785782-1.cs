    public class DbCtx : DbContext {
    public DbSet<Association> Associations { get; set; }
    public DbSet<Page> Pages { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Entity<Association>()
				.HasRequired(x => x.Page)
				.WithMany(x => x.Associations)
				.WillCascadeOnDelete(false);
		}
