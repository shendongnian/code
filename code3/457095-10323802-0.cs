    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public virtual ICollection<CustomerEvent> CustomerEvents { get; set; }
    }
    
    publix class CustomerEvent
    {
        public int CustomerEventId { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual int EventId { get; set; }
        public virtual Event Event { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
    }
    
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public virtual ICollection<CustomerEvent> CustomerEvents { get; set; }
    }
    
    public class Guest
    {
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public virtual ICollection<CustomerEvent> CustomerEvents { get; set; }
    }
