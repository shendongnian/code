    public static string ToXmlUsingDataContract<T>(T obj)
    {
        var dcs = new DataContractSerializer(typeof(T));
        var sb = new StringBuilder();
        using (var writer = XmlWriter.Create(sb))
        {
            dcs.WriteObject(writer, obj);
        }
        return (sb.ToString());
    }
