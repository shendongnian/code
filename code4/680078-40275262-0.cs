    [Serializable]
    public class UnserializableValueWrapper: IXmlSerializable
    {
        private static readonly BinaryFormatter Formatter = new BinaryFormatter();
    
        public UnserializableValueWrapper([NotNull] object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
    
            this.Value = value;
        }
    
        public UnserializableValueWrapper()
        {
        }
    
        public object Value { get; private set; }
    
        public XmlSchema GetSchema()
        {
            return null;
        }
    
        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
    
            var length = int.Parse(reader.GetAttribute("length"));
            reader.ReadStartElement("Data");
    
            var buffer = new byte[length];
            reader.ReadContentAsBase64(buffer, 0, length);
            using (var stream = new MemoryStream(buffer))
            {
                this.Value = Formatter.Deserialize(stream);
            }
    
            reader.ReadEndElement();
            reader.ReadEndElement();
        }
    
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Data");
    
            using (var stream = new MemoryStream())
            {
                Formatter.Serialize(stream, this.Value);
                var buffer = stream.ToArray();
                writer.WriteAttributeString("length", buffer.Length.ToString());
                writer.WriteBase64(buffer, 0, buffer.Length);
            }
    
            writer.WriteEndElement();
        }
    }
