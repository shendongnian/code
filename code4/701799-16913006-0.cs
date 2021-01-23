    public class Event
    {
        public int EventId { get; set; } 
        public string EventName { get; set; }
        // .....all your other properties
        public virtual ICollection<Team> Teams { get; set; }  // this along with the List<Event> property in Team will result in a M2M relationship
    }
