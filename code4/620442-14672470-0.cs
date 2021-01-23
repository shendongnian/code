    modelBuilder.Entity<Member>()
    .Map<Field>(m => 
    {
        m.ToTable("Fields");
        m.Requires("ValueType").HasValue((int)Service.DataTypes.MemberType.Field).IsRequired();
    })
    .Map<SECONDTYPE>(m =>
    {
        m.Requires("ValueType").HasValue(42);
    }); 
