    //If .NET 3.5, need this initialization:
    //Type xamlType = typeof(System.Windows.Markup.XamlReader);
    //LoadBamlMethod = xamlType.GetMethod(LOAD_BAML_METHOD, BindingFlags.NonPublic | BindingFlags.Static);
    public static T LoadBaml<T>(Stream stream) 
    { 
        //For .net 3.5: 
        //ParserContext parserContext = new ParserContext(); 
        //object[] parameters = new object[] { stream, parserContext, null, false }; 
        //object bamlRoot = LoadBamlMethod.Invoke(null, parameters); 
        //return (T)bamlRoot; 
        //For .net 4.0
        var reader = new Baml2006Reader(stream); 
        var writer = new XamlObjectWriter(reader.SchemaContext); 
        while (reader.Read()) 
                writer.WriteNode(reader); 
        return (T)writer.Result; 
    } 
