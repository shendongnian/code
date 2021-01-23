    public static bool IsValidXml(string xmlFilePath, string xsdFilePath, XNamespace namespaceName)
    {
        var xdoc = XDocument.Load(xmlFilePath);
        var schemas = new XmlSchemaSet();
        schemas.Add(namespaceName, xsdFilePath);
    
        try
        {
            xdoc.Validate(schemas, null);
        }
        catch (XmlSchemaValidationException)
        {
            return false;
        }
    
        return true;
    }
