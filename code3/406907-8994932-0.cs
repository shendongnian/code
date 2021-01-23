    public static string SerializeToXml<T>(T obj, PropertyInfo[] fields = null)
        where T : ITable
    {
        Type type = typeof(T);
        IEnumerable<PropertyInfo> ignoredProperties;
        if (fields == null)
            ignoredProperties = Enumerable.Empty<PropertyInfo>();
        else
            ignoredProperties = type.GetProperties(
                BindingFlags.Public | BindingFlags.Instance)
                .Except(fields);
        var ignoredAttrs = new XmlAttributes { XmlIgnore = true };
        var attrOverrides = new XmlAttributeOverrides();
        foreach (var ignoredProperty in ignoredProperties)
            attrOverrides.Add(type, ignoredProperty.Name, ignoredAttrs);
        var serializer = new XmlSerializer(type, attrOverrides);
        using (var writer = new StringWriter())
        {
            serializer.Serialize(writer, obj);
            return writer.ToString();
        }
    }
