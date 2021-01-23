    public class ImmoReportsEntities : DbContext
    {
        public DbSet<Liegenschaft> Liegenschaft { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Liegenschaft>()
                .HasMany(e => e.HausMenge)
                .WithRequired(e => e.Liegenschaft)
                .HasForeignKey(e => e.LiegenschaftId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Liegenschaft>()
                .HasMany(e => e.MieterMenge)
                .WithRequired(e => e.Liegenschaft)
                .HasForeignKey(e => e.LiegenschaftId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Liegenschaft>()
                .HasMany(e => e.MietzinsMenge)
                .WithRequired(e => e.Liegenschaft)
                .HasForeignKey(e => e.LiegenschaftId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Liegenschaft>()
                .HasMany(e => e.ObjektMenge)
                .WithRequired(e => e.Liegenschaft)
                .HasForeignKey(e => e.LiegenschaftId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Haus>()
                .HasMany(e => e.ObjektMenge)
                .WithRequired(e => e.Haus)
                .HasForeignKey(e => e.HausId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Objekt>()
                .HasMany(e => e.MietzinsMenge)
                .WithRequired(e => e.Objekt)
                .HasForeignKey(e => e.ObjektId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Objekt>()
                .HasMany(e => e.MieterMenge)
                .WithRequired(e => e.Objekt)
                .HasForeignKey(e => e.ObjektId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Mieter>()
                .HasMany(e => e.MietzinsMenge)
                .WithRequired(e => e.Mieter)
                .HasForeignKey(e => e.MieterId)
                .WillCascadeOnDelete(false);
        }
    }
