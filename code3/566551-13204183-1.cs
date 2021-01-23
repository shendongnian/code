    public static void SerializeToXml<T>(T objectToSerialize, string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(objectToSerialize.GetType());
        using (TextWriter textWriter = new StreamWriter(fileName))
        {
            serializer.Serialize(textWriter, objectToSerialize);
            textWriter.Close();
        }
    }
