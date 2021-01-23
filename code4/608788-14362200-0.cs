    [XmlRoot("RuleSet")]
    public class RuleSet
    {
        [XmlArray("Conditions")]
        [XmlArrayItem(typeof(AttributeEqualTo))]
        [XmlArrayItem(typeof(AttributeNotEqualTo))]
        public List<Condition> Conditions { get; set; }
    }
