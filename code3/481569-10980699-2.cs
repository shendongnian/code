    [Serializable]
    public class AnimalCollection : IXmlSerializable
    {
        public void WriteXml(XmlWriter writer)
        {
            // Repeat for the Cat
            writer.WriteStartElement("Dog");
            XmlSerializer serializer = new XmlSerializer(TypeOf(Dog));
            using (StringWriter stringWriter = new StringWriter())
                {
                    serializer.Serialize(stringWriter, _dog);
                    string value = stringWriter.ToString();
                    writer.WriteRaw(value);
                }
            writer.WriteEndElement();
        }
    }
