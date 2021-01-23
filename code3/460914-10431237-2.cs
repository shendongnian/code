    public void SaveValues(Values v)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Values));
        using(TextWriter textWriter = new StreamWriter(@"E:\TheFileYouWantToStore.xml"))
        {
            serializer.Serialize(textWriter, v);
            textWriter.close();
        }
    ...
    }
