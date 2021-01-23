    HasMany(p => p.Adjustments)
        .Element("Adjustment", e => e.Type<AdjustmentCustomMap>())
        .Cascade.AllDeleteOrphan()
        .Inverse())
        ;
