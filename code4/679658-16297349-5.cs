    public ParentMap()
    {
        Map(x => x.Number).Not.Nullable();
        HasMany(x => x.Children).Inverse()
                                .Cascade.All()
                                .Access.CamelCaseField(Prefix.Underscore);
    }
