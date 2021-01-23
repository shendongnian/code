    public static void AddIntraDayTestModel(string file, TestModel itemToAdd)
    {
        // load the previously saved xml 
        // (this assumes it is in a file, rather than a stream - but easy to change)
        var xmlDocument = new XmlDocument();
        xmlDocument.Load(file);
    
        // Make sure the new item to add doesn't have its own xml declaration as
        // we will be inserting it into another exisiting xml doc.
        var settings = new XmlWriterSettings
                           {
                               OmitXmlDeclaration = true,
                           };
    
        using (var ms = new MemoryStream())
        using (var writer = XmlWriter.Create(ms, settings))
        {
            // force the serializer to not add the default namespaces as
            // these will already exist on the root node of the loaded doc.
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            // Serialize our one item to add
            var serializer = new XmlSerializer(typeof (TestModel));
            serializer.Serialize(writer, itemToAdd, namespaces);
            writer.Flush();
            ms.Position = 0;
            // append our new item
            using (var reader = XmlReader.Create(ms))
            {
                var nodeToInsert = xmlDocument.ReadNode(reader);
                xmlDocument.DocumentElement.AppendChild(nodeToInsert);
            }
        }
    
        // save the updated doc - our work is done!
        xmlDocument.Save(file);
    }
