    public class EntityMap : ClassMap<Entity>
    {
        public EntityMap()
        {
            Id(x => x.Name).GeneratedBy.Assigned();
            Map(x => x.TimeStamp);
        }
    }
