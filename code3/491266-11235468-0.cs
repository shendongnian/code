    var ns = "http://schemas.microsoft.com/sharepoint/soap/";
    var xml = 
        @"<Result ID=""1,New"" xmlns=""" + ns + @""">" +
            @"<ErrorCode>0x00000000</ErrorCode>" +
            @"<ID />" +
            @"<z:row ows_ID=""6"" />" +
        @"</Result>";
	
    XmlNamespaceManager mgr = new XmlNamespaceManager(new NameTable());
    mgr.AddNamespace("z", "http://schemas.microsoft.com/sharepoint/soap/");
    XmlParserContext ctx = new XmlParserContext(null, mgr, null, XmlSpace.Default);
    XDocument resDoc;
    using( XmlReader reader = XmlReader.Create(new StringReader(xml), null, ctx) ) {
        resDoc = XDocument.Load(reader);
    }
    string newId = (from r in resDoc.Descendants(XName.Get("row",ns))
        select (string)r.Attribute("ows_ID")).First();
	
    Console.WriteLine( newId );		// prints "6"
