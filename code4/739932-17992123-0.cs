    public class Entity
    {
        public virtual long id { get; set; }
        public virtual string name { get; set; }
    }
    public class EntityMap : ClassMap<Entity>
    {
        public EntityMap()
        {
            Id(x => x.id).GeneratedBy.Identity();
            Map(x => x.name);
            Cache.ReadOnly();
        }
    }
