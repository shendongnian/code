    [AttributeUsage(AttributeTargets.Property)]
    public class RelatedPropertyAttribute: Attribute
    {
        public string RelatedProperty { get; private set; }
        public RelatedPropertyAttribute(string relatedProperty)
        {
           RelatedProperty = relatedProperty;
        }
    }
