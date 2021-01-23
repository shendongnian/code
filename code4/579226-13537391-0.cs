    public static T DeserializeWithDataContractSerializer<T>(this string xml)
    {
        var dataContractSerializer = new DataContractSerializer(typeof(T));
        using (var reader = new XmlTextReader( new StringReader(xml)))
        {
            return (T)dataContractSerializer.ReadObject(reader);
        }
    }
