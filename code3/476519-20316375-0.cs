    public class AttributeAssignmentExpressionElement : XACMLElement
    {
        [XmlAttribute]
        public string AttributeId { get; set; }
    
        [XmlAttribute]
        public Category Category { get; set; }
    
        [XmlIgnore]
        public bool CategorySpecified { get; set; }                   
    }
