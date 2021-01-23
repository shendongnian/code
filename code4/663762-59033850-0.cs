    modelBuilder.Entity<MyBaseClass>()
        .HasDiscriminator<MyEnum>("MyEnum")
        .HasValue<MyBaseClass>(MyEnum.Value0)
        .HasValue<DerivedOne>(MyEnum.Value1)
        .HasValue<DerivedTwo>(MyEnum.Value2);
