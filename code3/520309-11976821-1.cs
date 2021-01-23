     public class Model : DbContext
        {
            public DbSet<GalleryCategory> Categories { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<GalleryCategory>()
                   .HasMany(x => x.Subcategories)
                    .WithOptional()
                    .HasForeignKey(g => g.ParentID);
            }
        }
