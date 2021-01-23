        public class parent : IXmlSerializable
        {
            public int id { get; set; }
            public XmlSchema GetSchema()
            {
                throw new NotImplementedException();
            }
            public void ReadXml(XmlReader reader)
            {
                while (reader.Read())
                {
                    if (reader.Name == "child")
                    {
                        int parseValue;
                        int.TryParse(reader.Value, out parseValue);
                        this.id = parseValue;
                    }
                }
            }
            public void WriteXml(XmlWriter writer)
            {
                writer.WriteStartElement("parent");
                writer.WriteStartElement("child");
                writer.WriteAttributeString("id", this.id.ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();                
            }
        }
