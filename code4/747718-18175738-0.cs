    class SomeClass
    {
        public int ID {get;set;}
        public virtual IList<SupportTicketMessage> Messages { get; set; }
    }
    
    var entry = db.Set<SomeClass>().Include("Messages").Single(t => t.ID = 1);
