    [XmlRoot(ElementName = "Root")]
    public class TopLevel : IXmlSerializable
    {
        public string topLevelProperty;
        public NestedObject nestedObj;
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            //...
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("topLevelProperty", topLevelProperty);
            writer.WriteElementString("propertyOnNestedObject", nestedObj.propetyOnNestedObject);
        }
    }
