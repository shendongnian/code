    public class RuleApply
    {
        public int Id;
        public int type_id { get; set; }
        public int rule_id { get; set; }
        public virtual Rule Rule { get; set; }    
    }
