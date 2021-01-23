    [XmlRootAttribute("myDocument")]
    public class myDocument
    {
       [XmlArrayAttribute]
       publict ClassName[] ArrayOfClassName {get;set;}
    }
    
    [XmlType(TypeName="ClassName")]
    public class ClassName 
    {
       public string stuff {get;set;}
    }
