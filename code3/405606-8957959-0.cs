    public static void SerializeToXML<T>(String inFilename,T t) 
    {
        XmlSerializer serializer = new XmlSerializer(t.GetType());
        string FullName = inFilename;
        using (TextWriter textWriter = new StreamWriter(FullName))
        {
            serializer.Serialize(textWriter, t); 
            textWriter.Close();
        }
    }
