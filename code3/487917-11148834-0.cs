    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<WidgetEntity>()
         .HasRequired(w => w.Sequence)
         .WithMany()
         .Map(m => m.MapKey("WIDGETSEQUENCE_ID"));
    }
