    public class EventMap : ClassMap<Event>
    {
        public EventMap()
        {
           //the normal ID and property stuff
       
           References(x => x.ParentEvent).Column("ParentEventId");
    
           HasMany(x => x.Dependencies).KeyColumn("ParentEventId");
        }
    }
