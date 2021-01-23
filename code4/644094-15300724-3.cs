        var xmlDocument = new XmlDocument();
        xmlDocument.Load(...);
        var xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
        xmlNamespaceManager.AddNamespace("a", "http://localhost/scheme_a");
        xmlNamespaceManager.AddNamespace("b", "http://localhost/scheme_b");
        xmlNamespaceManager.AddNamespace("c", "http://localhost/scheme_c");
        xmlNamespaceManager.AddNamespace("d", "http://localhost/scheme_d");
        var bCatNodes = xmlDocument.SelectNodes("/xml/a:info/b:cat", xmlNamespaceManager);
        var option1Attributes = bCatNodes.Cast<XmlNode>().Select(node => node.Attributes["Option1"]);
        // Also, all Option1 attributes can be retrieved directly using XPath:
        // var option1Attributes = xmlDocument.SelectNodes("/xml/a:info/b:cat/@Option1", xmlNamespaceManager).Cast<XmlAttribute>();
