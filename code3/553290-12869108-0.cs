    public class MenuEntities : DbContext
    {
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
    
          protected override void OnModelCreating( DbModelBuilder modelBuilder )
          {
    
             modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
    
             modelBuilder.Entity<Menu>()
                .HasRequired( f => f.Status )
                .WithOptional()
                .WillCascadeOnDelete( false );
    
             modelBuilder.Entity<Restaurant>()
                .HasRequired( f => f.Status )
                .WithOptional()
                .WillCascadeOnDelete( false );
    
          }
    
    }
    
            
