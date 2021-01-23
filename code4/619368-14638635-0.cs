    public Entity2Config : EntityTypeConfiguration<Entity2>
    {
        HasMany(x => x.Entity1s)
            .WithRequired(x => x.Entity2)
            .HasForeignKey(x => x.Entity2_Id);
    }
    
    public Entity3Config : EntityTypeConfiguration<Entity3>
    {
        HasMany(x => x.Entity1s)
            .WithRequired(x => x.Entity3)
            .HasForeignKey(x => x.Entity3_Id);
    }
