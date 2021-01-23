    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ValueTypeId { get; set; }
        public int ParentQuestionId { get; set; }
        public virtual ValueType ValueType { get; set; }
        public virtual ICollection<BusinessRule> BusinessRules { get; set; }
    }
    public class BusinessRule
    {
        public int Id { get; set; }
        public string ValidationMessage { get; set; }
        public string ConditionValue { get; set; }
        public int BusinessRuleTypeId { get; set; }
        public virtual string BusinessRuleType { get; set; }
    }
