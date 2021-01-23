    // Create an XmlReader
    NameTable nt = new NameTable();
    XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
    nsmgr.AddNamespace("m", "www.namespacem.com"); // Placeholder uri
    nsmgr.AddNamespace("d", "www.namespaced.com"); // Placeholder uri
    XmlParserContext context = new XmlParserContext(nt, nsmgr, null, XmlSpace.None);
    using (XmlReader reader = XmlReader.Create(new StringReader(x), new XmlReaderSettings(), context))
    {
        // Do funky stuff
    }
