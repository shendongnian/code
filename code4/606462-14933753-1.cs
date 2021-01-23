    public void Write(string filePath, MyResponseClass myResponse)
    {
        var serializer = new DataContractSerializer(typeof(MyResponseClass));
        var sb = new StringBuilder();
        using (var writer = new StringWriter(sb))
        using (var xmlWriter = XmlWriter.Create(writer))
        {
            serializer.WriteObject(xmlWriter, myResponse);
        }
        using (StreamWriter stream = new StreamWriter(filePath))
        {
            sb = sb.Replace(" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
            stream.Write(sb);
        }
    }
