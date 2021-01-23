    public class Product{
        [XmlElement]
        public Cycle Cycle {get;set;}
        
        [XmlElement]
        public Brand Brand {get;set;}
        [XmlElement]
        public Updates Updates {get;set;}
    }
    public class Updates{
        [XmlElement("Item")]
        public UpdateItem[] Items{get;set;}
    }
    
    public class UpdateItem{ 
        [XmlAttribute]
        public string Name{get;set;} // use [XmlAttribute] in Cycle, Brand and Artifact classes
        [XmlElement("Artifact")]
        public Artifact[] Artifact{get;set;} 
    }
    //.... etc
