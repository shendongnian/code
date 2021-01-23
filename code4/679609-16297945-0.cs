    XmlSerializer ser = new XmlSerializer(typeof(General));
    var g = (General)ser.Deserialize(yourStream);
---
    public class General
    {
        [XmlElement("Component")]    
        public List<Component> Components { get; set; }
    }
        
    public class Component
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
    }
