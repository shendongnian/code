    // This is the class that will be serialized.  
    public class Group
    {
       // The GroupName value will be serialized--unless it's overridden. 
       public string GroupName;
    
       /* This field will be ignored when serialized--unless it's overridden. */
       [XmlIgnoreAttribute]
       public string Comment;
    }
