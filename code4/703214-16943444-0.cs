    public static body ReadObject(string fileName)
    {
        Console.WriteLine("Deserializing an instance of the object.");
        FileStream fs = new FileStream(fileName,
        FileMode.Open);
        XmlDictionaryReader reader =
           XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
        DataContractSerializer ser = new DataContractSerializer(typeof(body));
        // Deserialize the data and read it from the instance.
        body deserializedBody = (body)ser.ReadObject(reader, true);
        reader.Close();
        fs.Close();
        return deserializedBody;
    }
