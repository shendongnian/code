    public class SysObjectMap : EntityTypeConfiguration<SysObject>
    {
        HasKey(p => p.SomeUniqueId);
        Property(p => p.Name).IsRequired();
        ToTable("SysObjects"); // If there is Schema pass it as a 2nd argument
        Property(p => p.Name).HasColumnName("name");
    }
