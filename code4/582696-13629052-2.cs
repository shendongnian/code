    function ToXmlFile(object o, string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            var serializer = new Xml.Serialization.XmlSerializer(o.GetType();
            serializer.Serialize(writer, o);
            // Exception handling omitted for brevity
        }
    }
