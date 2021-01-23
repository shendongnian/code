    [XmlRoot("visibility")]
    public class Visibility : IXmlSerializable
    {
        public string Site;
        public string Comparator;
        public int Expiration;
        public string Comment;
        
        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
        public void ReadXml(XmlReader reader)
        {
            // implement me if you want to deserialize too.
            throw new NotImplementedException();
        }
        public void WriteXml(XmlWriter writer)
        {
            WriteProperty(writer, "site", "visible", Site);
            WriteProperty(writer, "comparator ", "visible", Comparator);
            WriteProperty(writer, "expiration ", "days", Expiration);
            
            if (!string.IsNullOrEmpty(Comment))
            {
                writer.WriteElementString("comment", Comment);
            }
        }
        private void WriteProperty<T>(XmlWriter writer, string elementName, string attibuteName, T value)
        {
            if (value != null)
            {
                writer.WriteStartElement(elementName);
                writer.WriteAttributeString(attibuteName, value.ToString());
                writer.WriteEndElement();
            }
        }
    }
