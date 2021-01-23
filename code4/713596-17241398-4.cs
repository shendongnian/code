    [XmlRoot("Class")]
    public sealed class ClassSerializerProxy : IXmlSerializable, ISerializerProxy<Class>
    {
        public Class Value {get;set;}
        
        public System.Xml.Schema.XmlSchema GetSchema(){return null;}
        public void WriteXml(System.Xml.XmlWriter writer){}
    
        public void ReadXml(System.Xml.XmlReader reader)
        {
            var x = XElement.ReadFrom(reader) as XElement;
            this.Value = new Class();
            this.Value.Property = x.XPathSelectElement("Property").Value;
        }
    }
