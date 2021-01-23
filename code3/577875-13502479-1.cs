    public interface EventDetails
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
    }
    public class SportingEvent
    {
        
        public EventDetails Details {get;set;}
    }
