    [XmlInclude(typeof(AsciiValidator))]
    [XmlInclude(typeof(RequiredValidator))]
    [XmlInclude(typeof(StringLengthValidator))]
    public class FieldValidator
    {
        [XmlElement("Next")]
        public FieldValidator Next
        {
        get;
        set;
        }
        
        [XmlElement("PropertyName")]
        public string PropertyName
        {
        get;
        set;
        }
    }
                
    public class AsciiValidator: FieldValidator
    {
    }
                
    public class RequiredValidator: FieldValidator
    {
    }
    
    public class StringLengthValidator: FieldValidator
    {
        [XmlElement]
        public int MinLength{get;set;}
        [XmlElement]
        public int MaxLength{get;set;}
    }
    
    [XmlRoot("ValidatorList")]
    public class ValidatorList : List<FieldValidator>
    {    
    }
