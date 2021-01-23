    public class Customer
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
    }
    public class Status
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
