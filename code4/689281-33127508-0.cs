    public class BaseItem
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime Created { get; set; }
    }
    public class Item : BaseItem
    {
        public virtual string Name { get; set; }
    }
    public class Child1 : Item
    {
        public virtual int Property1 { get; set; }
    }
    public class Child2 : Item
    {
        public virtual int Property2 { get; set; }
    }
    public class ItemMap : ClassMap<Item>
    {
        public ItemMap()
        {
            Id(p => p.Id).Column("BaseItemId").GeneratedBy.HiLo("100");
            Join("BaseItemTable", join =>
            {
                join.KeyColumn("BaseItemId");
                join.Map(x => x.Created);
            });
            DiscriminateSubClassesOnColumn("ItemType");
        }
    }
    public class Child1Map : SubclassMap<Child1>
    {
        public Child1Map()
        {
            DiscriminatorValue("Child1");
            Map(x => x.Property1);
        }
    }
    public class Child2Map : SubclassMap<Child2>
    {
        public Child2Map()
        {
            DiscriminatorValue("Child2");
            Map(x => x.Property2);
        }
    }
