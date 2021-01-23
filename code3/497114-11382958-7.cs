    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {    
        modelBuilder.Entity<Recipe>()
            .HasMany(x => x.Members)
            .WithMany(x => x.Recipes)
        .Map(x =>
        {
            x.ToTable("Cookbooks"); // third table is named Cookbooks
            x.MapLeftKey("RecipeId");
            x.MapRightKey("MemberId");
        });
    }
