    using System;
    using System.Text;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
      [Serializable]
      public class AlphaNumericSort : IComparable, IXmlSerializable
      {
    ...
        // Xml Serialization Infrastructure 
        public void WriteXml (XmlWriter writer)
        {
            writer.WriteString(_Value);
        }
        public void ReadXml (XmlReader reader)
        {
            _Value = reader.ReadString();
        }
        public XmlSchema GetSchema()
        {
            return(null);
        }
