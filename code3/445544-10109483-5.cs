    public static bool IsValidXml(string xmlFilePath, string xsdFilePath, XNamespace namespaceName)
    {
        var xdoc = XDocument.Load(xmlFilePath);
        var schemas = new XmlSchemaSet();
        schemas.Add(namespaceName, xsdFilePath);
    
        Boolean result = true;
        xdoc.Validate(schemas, (sender, e) =>
             {
                 result = false;
             });
    
        return result;
    }
