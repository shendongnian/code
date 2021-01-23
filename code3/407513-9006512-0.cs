    [Obfuscate(Exclude=true)]
    [XmlRoot("ParentClass")]  
    public class ParentClass  
    {  
        [XmlArray("ChildClasses")]  
        public List<ChildClass> ChildClasses;  
    }  
    [Obfuscate(Exclude=true)]    
    [XmlType("ChildClass")]  
    public class ChildClass  
    {  
        [XmlElement("Property")]  
        public string Property;  
    }  
