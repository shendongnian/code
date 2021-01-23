    public class IOPoint
    {
     public string Name {get; set;}
    
     [XmlIgnore]
     public TypeEnum TypeEnum {get; set;}
    
     [XmlElement("TypeEnum")]
     public string LegacyTypeEnum 
     {
      get { return this.TypeEnum.ToString(); }
      set 
      { 
       try
       {
    	this.TypeEnum = (TypeEnum)Enum.Parse(typeof(TypeEnum),value);
       }
       catch(ArgumentException)
       {
       }
       catch(OverflowException)
       {
       }
      }
     }
    }
