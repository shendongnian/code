    public class NewCVXml : IXmlSerializable {
    
        public List<string> FieldFirst { get; set; }
        public List<string> FieldSecond { get; set; }
        public List<string> FieldThird { get; set; }
    
        public void WriteXml (XmlWriter writer)
        {
            // Custom Serialization Here
        }
    
        public void ReadXml (XmlReader reader)
        {
            // Custom Deserialization Here
        }
    
        public XmlSchema GetSchema()
        {
            return(null);
        }
    
    }
