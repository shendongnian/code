    public class AttributeValueElement : XACMLElement
    {
        public AttributeValueElement()
            : base(XacmlSchema.Context)
        {
            
        }
        [XmlAttribute]
        public string DataType { get; set; }
        [XmlText]
        public string Value 
        { 
            get { return DataValue.GetValue().ToString(); }
            set
            {
                DataValue = AttributeValueFactory.Create(DataType, value);   
            }
        }
        public AttributeValue DataValue { get; set; }        
    }
    public abstract class AttributeValue
    {
        public AttributeValue()
        {
           
        }
        public abstract object GetValue();
    }
    public class AttributeValue<T> : AttributeValue
    {
        public T Value { get; set; }
        public override object GetValue()
        {
            return Value;
        }
    }
