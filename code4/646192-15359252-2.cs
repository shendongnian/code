    public class RuleApply
    {
        public int Id; // entity should have primary key
        public int type_id { get; set; }
        public int rule_id { get; set; }
        [ForeignKey("rule_id")]
        public virtual Rule Rule { get; set; } 
    }
