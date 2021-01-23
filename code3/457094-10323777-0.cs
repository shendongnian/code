    public class Guest
    {
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Patron { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
    
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
    
    public class Customer
    {
        public int CustomerId { get; set; }
        public int EventId { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
        public virtual Event Event { get; set; }
    }
