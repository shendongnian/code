    string serviceUrl = "http://localhost/E-WebServices/WSCustomer.asmx";
    var client = new WebClient();
    ServiceDescription descr;
    using (var stream = client.OpenRead(serviceUrl + "?wsdl"))
    {
        descr = ServiceDescription.Read(stream);
    }
    var importer = new ServiceDescriptionImporter()
    {
        ProtocolName = "Soap12",
        Style = ServiceDescriptionImportStyle.Client,
        CodeGenerationOptions = CodeGenerationOptions.GenerateProperties,
    };
    importer.AddServiceDescription(descr, null, null);
    // Add any imported schemas
    var importedSchemas = new List<string>();
    foreach (XmlSchema wsdlSchema in descr.Types.Schemas)
    {
        foreach (XmlSchemaObject externalSchema in wsdlSchema.Includes)
        {
            if (externalSchema is XmlSchemaImport)
            {
                XmlSchemaImport schemaImport = externalSchema as XmlSchemaImport;
                var split = schemaImport.Namespace.Split(new char[] { '/', '.' });
                string schemaId = split[split.Count() - 2];
                if (importedSchemas.Contains(schemaId))
                    continue;
                importedSchemas.Add(schemaId);
                Uri schemaUri = new Uri(serviceUrl + "?schema=" + schemaId);
                XmlSchema schema;
                using (var wsdlStream = client.OpenRead(schemaUri))
                {
                    schema = XmlSchema.Read(wsdlStream, null);
                }
                importer.Schemas.Add(schema);
            }
        }
    }
    var nmspace = new CodeNamespace();
    var unit1 = new CodeCompileUnit();
    unit1.Namespaces.Add(nmspace);
    var warning = importer.Import(nmspace, unit1);
    if (warning == 0)
    {
        CodeDomProvider provider1 = CodeDomProvider.CreateProvider("CSharp");
        string[] assemblyReferences = new string[5] { "System.dll", "System.Web.Services.dll", "System.Web.dll", "System.Xml.dll", "System.Data.dll" };
        CompilerParameters parms = new CompilerParameters(assemblyReferences);
        CompilerResults results = provider1.CompileAssemblyFromDom(parms, unit1);
        if (results.Errors.Count > 0)
        {
            foreach (CompilerError oops in results.Errors)
                Debug.WriteLine(oops.ErrorText);
            throw new Exception("Compile Error Occured calling webservice");
        }
        object service = results.CompiledAssembly.CreateInstance("WSCustomer");
        Type t = service.GetType();
        List<MethodInfo> methods = t.GetMethods().ToList();
        // use them somehow
    }
