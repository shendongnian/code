    public class ParentMap : ClassMap<Parent>
    {
        public ParentMap()
        {
            this.Table("Parents");
            this.Id(x => x.Id);
            this.Map(x => x.Name);
            this.HasMany(x => x.Childs).KeyColumn("ChildId").Cascade.AllDeleteOrphan();
        }
    }
    
    public class ChildMap : ClassMap<Child>
    {
        public ChildMap()
        {
            this.Table("Childs");
            this.Id(x => x.Id);
            this.Map(x => x.Name);
            this.Map(x => x.ParentId);
        }
    }
