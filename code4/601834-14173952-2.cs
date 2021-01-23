    public class ContactEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
    
        public virtual ICollection<ContactEventAttendee> ContactEventAttendees {get; set;}
    }
