    public class IntegerValue
    {
       public int value {get; set;}
    
       [XmlAnyAttribute]
       public XmlAttribute[] XAttributes { get; set; }
    }
