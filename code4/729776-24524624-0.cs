    private static XmlNamespaceManager AttachNamespaces(XmlDocument xmldoc)
        {
            XmlNamespaceManager nsMgr = new XmlNamespaceManager(xmldoc.NameTable);
            XmlNode rootnode = xmldoc.DocumentElement;
            string strTest = GetAttribute(ref rootnode, "xmlns");
            nsMgr.AddNamespace("mysite", string.IsNullOrEmpty(strTest) ? "http://example.com/" : strTest);
            // Add namespaces from XML root tag
            if (rootnode.Attributes != null)
                foreach (XmlAttribute attr in rootnode.Attributes)
                {
                    string attrname = attr.Name;
                    if (attrname.IndexOf("xmlns", StringComparison.Ordinal) == 0 && !string.IsNullOrEmpty(attrname))
                    {
                        if (attrname.Length == 5) // default Namespace
                        {
                            string ns = "default";
                            nsMgr.AddNamespace(ns, attr.Value);
                        }
                        else if (attrname.Length > 6)
                        {
                            string ns = attrname.Substring(6);
                            nsMgr.AddNamespace(ns, attr.Value);
                        }
                    }
                }
            return nsMgr;
        }
