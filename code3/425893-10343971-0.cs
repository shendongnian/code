    public class CustomXmlTextWriter : XmlTextWriter
    {    
      public override void WriteStartElement(string prefix, string localName, string ns)
      {
        base.WriteStartElement(null, localName, "");
      }
    }
