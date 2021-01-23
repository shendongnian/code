    public class MyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .HasMany(p => p.Cuisines)
                .WithMany(r => r.Restaurants)
                .Map(mc =>
                {
                    mc.MapLeftKey("RestaurantId");
                    mc.MapRightKey("CuisineId");
                    mc.ToTable("RestaurantCuisines");
                });
         }
    }
