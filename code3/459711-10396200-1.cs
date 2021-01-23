    public static object Deserialize(string xml)
    {
        var deserializer = new System.Xml.Serialization.XmlSerializer(typeof(RPMConfiguration));
        using (var reader = XmlReader.Create(new StringReader(xml)))
        {
            return (RPMConfiguration)deserializer.Deserialize(reader);
        }
    }
