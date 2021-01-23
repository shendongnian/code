    public partial class XpathMappingSetMap : EntityTypeConfiguration<XpathMappingSet>
    {
        public XpathMappingSetMap()
        {
            ToTable("XpathMappingSets");
            HasKey(m => m.XpathMappingSetId);
            Property(m => m.XpathMappingSetId).HasColumnName("MappingSetId");
        }
    }
