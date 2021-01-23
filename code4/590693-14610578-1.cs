    var dataType = data.GetType();
    var xmlAttribute = (XmlTypeAttribute)Attribute.GetCustomAttribute(dataType, typeof(XmlTypeAttribute));
    XNamespace ns = xmlAttribute.Namespace;
    using (var fileWriter = new StreamWriter(filePath))
    {
       var xSerializer = new XmlSerializer(dataType, ns.NamespaceName);
       xSerializer.Serialize(fileWriter, data);
       fileWriter.Close();    
    }
