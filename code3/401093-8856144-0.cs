    XPathDocument document = new XPathDocument(xml);
    XPathNavigator navigator = document.CreateNavigator();
    //Get namespaces & add them to the search
    bool hasDAV = false;
    string davPrefix = "D";
    XmlNamespaceManager nsman = new XmlNamespaceManager(navigator.NameTable);
    foreach (KeyValuePair<string, string> nskvp in navigator.GetNamespacesInScope(XmlNamespaceScope.All))
    {
        if (string.Compare(nskvp.Value, "DAV:", StringComparison.InvariantCultureIgnoreCase) == 0)
        {
            hasDAV = true;
            davPrefix = nskvp.Key;
        }
        nsman.AddNamespace(nskvp.Key, nskvp.Value);
    }
    if (!hasDAV)
        nsman.AddNamespace(davPrefix , "DAV:");
    XPathNodeIterator iterator = navigator.Select("/" + davPrefix + ":" + WebDavXML.PropFind + "/*", nsman);
