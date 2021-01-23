    public ProductMap()
    {
        Id(x => x.Id);
        Map(x => x.Name).Length(255).Nullable();
        HasManyToMany(x => x.Stores)
            .AsBag()
            .Table("StoreProduct")
    }
