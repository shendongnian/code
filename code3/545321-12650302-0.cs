    public T Deserialize<T>(string xml)
    {
        T deserialized;
        XmlSerializer xmlSerializer= new XmlSerializer(typeof(T));
        using (StringReader stringReader = new StringReader(xml))
        {
            var xmlReaderSettings = new XmlReaderSettings(); //
            using (XmlReader xmlReader = XmlReader.Create(stringReader, xmlReaderSettings))
            {
                xmlReader.MoveToContent();
                deserialized = (T)xmlSerializer.Deserialize(xmlReader);
            }
        }
        return deserialized;
    }
