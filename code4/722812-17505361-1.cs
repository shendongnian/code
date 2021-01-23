    public class EventItems
    {
        public EventItems()
        {
            Events = new List<EventItem>();
        }
        
        public List<EventItem> Events { get; set; }
    }
    
    public class EventItem
    {
        public string World_ID { get; set; }
        public string Map_ID { get; set; }
        public string Event_ID { get; set; }
        public string State { get; set; }        
    }
