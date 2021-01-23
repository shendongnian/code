    XmlNamespaceManager ns = new XmlNamespaceManager(cd.NameTable);
            ns.AddNamespace("sp", "http://schemas.xmlsoap.org/soap/envelope/");
            ns.AddNamespace("sc", "http://sitecore.net/visual/");
            XmlNode sitecoreRoot = cd.SelectSingleNode("//sp:Envelope/sp:Body/sc:GetXMLResponse/sc:GetXMLResult/sitecore/status", ns);
    var status = sitecoreRoot.InnerText;
