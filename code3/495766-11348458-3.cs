    XmlDocument xml = new XmlDocument();
    xml.Load("sitemap.xml");
    XmlNamespaceManager manager = new XmlNamespaceManager(xml.NameTable);
    manager.AddNamespace("s", xml.DocumentElement.NamespaceURI); //Using xml's properties instead of hard-coded URI
    XmlNodeList xnList = xml.SelectNodes("/s:sitemapindex/s:sitemap", manager);
