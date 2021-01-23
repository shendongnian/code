    using (WebClient w = new WebClient())
    {
        string xml = w.DownloadString("http://webservices.nextbus.com/service/publicXMLFeed?command=routeConfig&a=sf-muni&r=N");
        XDocument xDoc = XDocument.Parse(xml);
        var result = xDoc.Descendants("stop")
                        .Select(n => new
                        {
                            Tag = (string)n.Attribute("tag"),
                            Title = (string)n.Attribute("title"),
                            Lat = (string)n.Attribute("lat"),
                            Lon = (string)n.Attribute("lon"),
                            StopId = (string)n.Attribute("stopId")
                        })
                        .ToArray();
    }
