    [XmlRoot("Class")] // <-- Very important
    public sealed class ClassSerializerProxy : IXmlSerializable
    {
        public Class ClassValue {get;set;}
        
        public System.Xml.Schema.XmlSchema GetSchema(){return null;}
        public void WriteXml(System.Xml.XmlWriter writer){}
    
        public void ReadXml(System.Xml.XmlReader reader)
        {
            var x = XElement.ReadFrom(reader) as XElement;
            this.ClassValue = new Class();
            //again this is a simple contrived example
            this.ClassValue.Property = x.XPathSelectElement("Property").Value;
        }
    }
