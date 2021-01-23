    public DocumentMap()
    {
        Id(c => c.Id)
            .Column("dId")
            .GeneratedBy.HiLo("10");
        Map(c => c.Name)
            .Column("dName");
        HasMany(c => c.Options)
            .Component(c =>
                           {
                               c.Map(c2 => c2.Value).Column("oValue");
                               c.Map(c2 => c2.Type).Column("oType");
                           })
            .KeyColumn("dId")
            .Cascade.AllDeleteOrphan();
    }
