    [XmlRoot(ElementName="Root")] 
    public class TopLevel 
    {    
       public string topLevelProperty;    
    
       [XmlIgnore]
       public NestedObject nestedObj; 
    
       [XmlElement("NestedProperty")]
       public string NestedPropertyAccessor
       {
           get
           {
             return nestedObj.NestedProperty;
           }
           // set
       }
    } 
