    public class RuleApply
    {
        [Key, Column(Order=0)]
        public int type_id { get; set; }
        [Key, Column(Order=1)]
        public int rule_id { get; set; }
        public virtual Rule Rule { get; set; }    
    }
