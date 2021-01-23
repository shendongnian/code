    public class Request
    {
        [Key]
        public int RequestID { get; set; }
        public string RequestDescription { get; set; }
        public int RequestPriority { get; set; }
        public string RequestStub { get; set; }
        public int RequesterID { get {return Requester.Id} }
        public int AdminID { get {return Admin.Id} }
        public bool RequestAnsweredFlag { get; set; }
        public bool RequestSeenFlag { get; set; }
    
        public virtual User Requester {get;set;}
        public virtual User Admin { get; set; }
    
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    }
