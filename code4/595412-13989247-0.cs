    private static void ValidateXmlFile()
    {
    	using (var xmlFile = File.OpenRead("networkshares.xml"))
    	using (var xmlSchemaFile = ResourceUtility.LoadResource("networkshares.xsd"))
    	{
    		XmlUtility.ValidateXml("netuseperdomain.networkshares", xmlSchemaFile, xmlFile);
    	}
    }
    
    public static void ValidateXml(string targetNamespace, Stream xmlSchema, Stream xml)
    {
    	var xdoc = XDocument.Load(xml);
    	var schemas = new XmlSchemaSet();
    	schemas.Add(targetNamespace, new XmlTextReader(xmlSchema));
    
    	xdoc.Validate(schemas, (sender, e) =>
    	{
    		throw new Exception(e.Message);
    	});
    }
