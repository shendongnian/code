    // Create a namespace manager
    XmlNamespaceManager namespaceManager = new XmlNamespaceManager(new NameTable());
    
    // Define your default namespace including a prefix to be used later in the XPath expression
    namespaceManager.AddNamespace("xhtml", "http://www.w3.org/1999/xhtml");
    
    // Select the node using XPath
    var bodyByXPath = doc.XPathSelectElement("/xhtml:html/xhtml:body", namespaceManager);
