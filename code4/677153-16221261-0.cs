    [XmlRoot("ComplexTypeA")]
    public class ComplexTypeA : IXmlSerializable
    {
        public int Value { get; set; }
    
        public void WriteXml (XmlWriter writer)
        {
            writer.WriteAttributeString("Type", this.GetType().FullName);
            writer.WriteValue(this.Value.ToString());
        }
    
        public void ReadXml (XmlReader reader)
        {
            reader.MoveToContent();
            if (reader.HasAttributes) {
                if (reader.GetAttribute("Type") == this.GetType().FullName) {
                    this.Value = int.Parse(reader.ReadString());
                }
            }
        }
    
        public XmlSchema GetSchema()
        {
            return(null);
        }
    }
    
    [XmlRoot("ComplexTypeB")]
    public class ComplexTypeB : IXmlSerializable
    {
        public string Value { get; set; }
    
        public void WriteXml (XmlWriter writer)
        {
            writer.WriteAttributeString("Type", this.GetType().FullName);
            writer.WriteValue(this.Value);
        }
    
        public void ReadXml (XmlReader reader)
        {
            reader.MoveToContent();
            if (reader.HasAttributes) {
                if (reader.GetAttribute("Type") == this.GetType().FullName) {
                    this.Value = reader.ReadString();
                }
            }
        }
    
        public XmlSchema GetSchema()
        {
            return(null);
        }
    }
    
    
    [XmlRoot("ComplexTypeC")]
    public class ComplexTypeC : IXmlSerializable
    {
        public Object ComplexObj { get; set; }
    
        public void WriteXml (XmlWriter writer)
        {
            writer.WriteAttributeString("Type", this.GetType().FullName);
            if (this.ComplexObj != null)
            {
                writer.WriteAttributeString("IsNull", "False");
                writer.WriteAttributeString("SubType", this.ComplexObj.GetType().FullName);
                if (this.ComplexObj is ComplexTypeA)
                {
                    writer.WriteAttributeString("HasValue", "True");
                    XmlSerializer serializer = new XmlSerializer(typeof(ComplexTypeA));
                    serializer.Serialize(writer, this.ComplexObj as ComplexTypeA);
                }
                else if (tthis.ComplexObj is ComplexTypeB)
                {
                    writer.WriteAttributeString("HasValue", "True");
                    XmlSerializer serializer = new XmlSerializer(typeof(ComplexTypeB));
                    serializer.Serialize(writer, this.ComplexObj as ComplexTypeB);
                }
                else
                {
                    writer.WriteAttributeString("HasValue", "True");
                }
            }
            else
            {
                writer.WriteAttributeString("IsNull", "True");
            }
        }
    
        public void ReadXml (XmlReader reader)
        {
            reader.MoveToContent();
            if (reader.HasAttributes) {
                if (reader.GetAttribute("Type") == this.GetType().FullName) {
                    if ((reader.GetAttribute("IsNull") == "False") && (reader.GetAttribute("HasValue") == "True")) {
                        if (reader.GetAttribute("SubType") == typeof(ComplexTypeA).FullName)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(ComplexTypeA));
                            this.ComplexObj = serializer.Deserialize(reader) as ComplexTypeA;
                        }
                        else if (reader.GetAttribute("SubType") == typeof(ComplexTypeB).FullName)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(ComplexTypeB));
                            this.ComplexObj = serializer.Deserialize(reader) as ComplexTypeB;
                        }
                    }
                }
            }
        }
    
        public XmlSchema GetSchema()
        {
            return(null);
        }
    }
