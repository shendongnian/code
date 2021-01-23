    public class Audit
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string AffectedId { get; set; }       
        public string NewValue { get; set; }
        public virtual Action1 Action1 { get; set; }
        public virtual Action2 Action2 { get; set; }
    	public int? Action1Id {get; set;}
    	public int? Action2Id {get; set;}
    }
