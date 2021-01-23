    public class Leaf1Mapping : ClassMap<Leaf1>
    {
        public Leaf1Mapping()
        {
            Table("LeafTable1");
            Id(c => c.ID, "RowID").GeneratedBy.Identity();
            Map(c => c.Info1).Length(20);
            Map(c => c.Info2).Length(20);
            References(c => c.Parent).Column("Parent").LazyLoad();
            Map(c => c.ParentId).Column("Parent").ReadOnly();
        }
    }
