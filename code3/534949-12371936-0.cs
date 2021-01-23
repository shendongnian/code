    public class Event
    {
        public int EventId { get; set; }
        public Status Status { get; set; }
    }
    public enum Status
    {
        Open,
        Closed,
        Pending
    }
