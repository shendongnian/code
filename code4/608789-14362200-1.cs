    public class RuleSet
    {
        [XmlArrayItem(typeof(AttributeEqualTo))]
        [XmlArrayItem(typeof(AttributeNotEqualTo))]
        public List<Condition> Conditions { get; set; }
    }
    public class Condition
    {
        public string Id { get; set; }
        public string AttributeName { get; set; }
        public string ExpectedValue { get; set; }
    }
    public class AttributeEqualTo : Condition
    {
        // code
    }
    public class AttributeNotEqualTo : Condition
    {
        // code
    }
