    public class ContactEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public  ICollection<ContactEventAttendee> _attendees  { get; set;}
    }
    public class ContactEventAttendee
    {
        public int Id { get; set; }
        public Guid RowId { get; set; }
        public int RowVersionId { get; set; }
        public int SourceSiteNumber { get; set; }
        public virtual ContactEvent ContactEvent { get; set; }
    }
