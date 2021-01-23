    public class EventMap : ClassMap<Event>
        {
            public EventMap()
            {
               //the normal ID and property stuff
        
               HasManyToMany(x => x.Dependencies).Table("EventDependentEvent").AsBag();
            }
        }
