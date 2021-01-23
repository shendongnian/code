        String sitemap = "http://www.site.com/siteindex.xml"; 
        XmlDocument xml = new XmlDocument(); 
        xml.Load(sitemap); 
        XmlNamespaceManager manager = new XmlNamespaceManager(xml.NameTable); 
        manager.AddNamespace("s", xml.DocumentElement.NamespaceURI); //Using xml's properties instead of hard-coded URI  
        XmlNodeList xnList = xml.SelectNodes("/s:sitemapindex/s:sitemap", manager); 
 
        var parallelLoop1 = xnList.Count; 
        Parallel.For(0, parallelLoop1, parOptions, index => 
        { 
            String NAME = xnList[index]["loc"].InnerText; 
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(NAME); 
            req.Timeout = 1000 * 60 * 60; // milliseconds  
            System.Net.WebResponse res = req.GetResponse(); 
            Stream responseStream = res.GetResponseStream(); 
                GZipStream zip = new GZipStream(responseStream, CompressionMode.Decompress);
                XmlDocument xml2 = new XmlDocument();
                xml2.Load(zip);
            responseStream.Close(); 
    ......... more code 
        } 
