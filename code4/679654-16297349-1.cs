    public ParentMap()
    {
        Map(x => x.Number).Not.Nullable();
        // something like this, this is from memory
        HasMany(x => x.Children).Inverse().Cascade.All().Access.CamelCased(Prefix.Underscore);
    }
