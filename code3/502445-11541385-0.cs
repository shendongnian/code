    public class IncidentMap : ClassMap<Incident>
    {
        public IncidentMap()
        {
            Id(x => x.ID).GeneratedBy.Identity();
    
            HasManyToMany(x => x.Events)
                .Table("IncidentEvent")
                .ParentKeyColumn("IncidentID")
                .ChildKeyColumn("EventID")
                .ChildWhere("type=" + (int)SystemValue.Type.Event);
        }
    }
    public class Event
    {
        private EventDetails Details { get; set; }
        public string Name { get { return Details.Name; } set { Details.Name = value; } }
    
    }
    
    class EventDetails : SystemValue
    {
        public virtual string Name { get; set; }
    }
    
    public class EventMap : ClassMap<Event>
    {
        public EventMap()
        {
            Table("IncidentEvent");
    
            Id(x => x.Id, "Id").GeneratedBy.Identity();
    
            References(x => x.Incident, "IncidentID");
            References(Reveal.Member<Event>("Details"), "EventID").Not.LazyLoad();
    
            HasManyToMany(x => x.Causes)
                .Table("IncidentEventCause")
                .ParentKeyColumn("IncidentEventID")
                .ChildKeyColumn("CauseID");
        }
    }
    
    public class EventDetailsMap : SubclassMap<EventDetails>
    {
        public EventDetailsMap()
        {
            DiscriminatorValue((int)SystemValue.Type.Event);
            Map(x => x.Name);
        }
    }
    
    public class CauseMap : SubclassMap<Cause>
    {
        public CauseMap()
        {
            DiscriminatorValue((int)SystemValue.Type.Cause);
            Map(x => x.Name);
        }
    }
