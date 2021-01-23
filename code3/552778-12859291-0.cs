    public void WriteXml(XmlWriter writer)
    {
        writer.WriteElementString("Identifier", Identifier.ToString("d"));
        XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
        foreach (TKey key in Attributes.Keys)
        {
            writer.WriteStartElement(key.ToString());
            TValue value = Attributes[key];
            if (value == null)
                writer.WriteValue(String.Empty); //render empty ones.
            else
                writer.WriteValue(value.ToString());
            writer.WriteEndElement();
        }
    }
