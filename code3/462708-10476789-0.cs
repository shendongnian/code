    var mngr = new XmlNamespaceManager( new NameTable() );
    mngr.AddNamespace( "ss", "urn:ignore" ); // or proper URL
    var parserContext = new XmlParserContext(null, mngr, null, XmlSpace.None, null);
    var txtReader = new XmlTextReader( xml, XmlNodeType.Element, parserContext );
    var ele = XElement.Load( txtReader );
