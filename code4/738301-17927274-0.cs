    private static XElement XPathSelectElementDefaultNamespace(XDocument document,
                                                               string element)
    {
        XElement result;
        string xpath;
        
        var ns = document.Root.GetDefaultNamespace().ToString();
    
        if(string.IsNullOrWhiteSpace(ns))
        {
            xpath = string.Format("//{0}", element);
            result = document.XPathSelectElement(xpath);
        }
        else
        {
            var nsManager = new XmlNamespaceManager(new NameTable());
            nsManager.AddNamespace(ns, ns);
            
            xpath = string.Format("//{0}:{1}", ns, element);
            result = document.XPathSelectElement(xpath, nsManager);
        }
        
        return result;
    }
