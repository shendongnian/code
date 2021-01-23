    private static XmlNamespaceManager AddNamespaces(XmlDocument xmlDoc)
    {
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
        AddNamespaces(xmlDoc.ChildNodes, nsmgr);
        return nsmgr;
    }
    private static void AddNamespaces(XmlNodeList nodes, XmlNamespaceManager nsmgr) {
        if (nodes == null)
            throw new ArgumentException("XmlNodeList is null");
        if (nsmgr == null)
            throw new ArgumentException("XmlNamespaceManager is null");
        foreach (XmlNode node in nodes)
        {
            if (node.NodeType == XmlNodeType.Element)
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    if (attr.Name.StartsWith("xmlns:"))
                    {
                        String ns = attr.Name.Replace("xmlns:", "");
                        nsmgr.AddNamespace(ns, attr.Value);
                    }
                }
                if (node.HasChildNodes)
                {
                    nsmgr.PushScope();
                    AddNamespaces(node.ChildNodes, nsmgr);
                    nsmgr.PopScope();
                }
            }
        }
    }
