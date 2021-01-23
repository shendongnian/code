    modelBuilder.Entity<OrderMenuItem>()
        .HasRequired(o => o.Order)
        .WithMany(o => o.Items)
        .HasForeignKey(o => o.OrderId);
    modelBuilder.Entity<OrderMenuItem>()
        .HasRequired(o => o.MenuItem)
        .WithMany() // a MenuItem can be ordered in many orders
        .HasForeignKey(o => o.MenuItemId);
    modelBuilder.Entity<OrderMenuItem>()
        .HasMany(o => o.MenuItemExtras)
        .WithMany() // an Extra can be ordered in many orders
        .Map(m => {
            m.ToTable("OrderMenuItemMenuItemExtras");
            m.MapLeftKey("OrderMenuItemId");
            m.MapRightKey("MenuItemExtraId");
        });
    
