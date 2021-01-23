    public class Derived1 : BaseClass, IXmlSerializable 
    { 
      public XmlSchema GetSchema() { return null; }
    
      public void ReadXml(System.Xml.XmlReader reader)
      {
        reader.MoveToContent();
        Name = reader.GetAttribute("Name");
        reader.ReadStartElement();
        if (!reader.IsEmptyElement)
        {
          YourProperty = reader.ReadElementString("YourElem");
          reader.ReadEndElement();
        }
      }
    
      public void WriteXml(System.Xml.XmlWriter writer)
      {
        witer.WriteAttributeString("Name", Name);
        writer.WriteElementString("YourElem", "ThisIsMyContent");
      }
    }
