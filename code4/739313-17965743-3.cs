    // Base Class
    [Serializable]
    [XmlInclude(typeof(ConcreteChild))]
    public class BaseChild
    {
        public BaseChild()
        {
            ChildName = "Base";
        }
        public String ChildName { get; set; }
    }
    // Exposing Parent Property
    [Serializable]
    public class ConcreteChild : BaseChild
    {
        public new String ChildName { get; set; }
        public String BaseChildName { 
            get
            {
                return ((BaseChild) this).ChildName;
            }
            set
            {
                ((BaseChild)this).ChildName = value;
            }
        }
    }
    // Writing Custung Serializable
    [Serializable]
    public class ConcreteChild2 : BaseChild, IXmlSerializable
    {
        public new String ChildName { get; set; }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("InherittedChild");
            writer.WriteElementString("ConcreteChildName", ChildName);
            writer.WriteEndElement();
            // Since BaseChild does not implement IXmlSerializable
            // we cannot use base.WriteXml(writer);
            writer.WriteElementString("BaseChildName", ((BaseChild) this).ChildName);
        }
    }
    [XmlInclude(typeof(ConcreteChild))]
    [XmlInclude(typeof(ConcreteChild2))]
    [Serializable]
    public class MyClass
    {
        public BaseChild Left { get; set; }
        [XmlElement("ConcreteChild2", typeof(ConcreteChild2))]  // does not work without !!!
        public BaseChild Right { get; set; }
    }
