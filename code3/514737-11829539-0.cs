    public Dictionary<string, Dictionary<string, string>> getDictionary()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(@"path/to/file.xml");
        Dictionary<string, Dictionary<string, string>> outer = new Dictionary<string, Dictionary<string, string>>();
        Dictionary<string, string> inner;
        //cycle through outer nodes
        foreach (XmlNode service in doc.SelectNodes("/configuration/ServiceInstances/ServiceInstance"))
        {
            inner = new Dictionary<string, string>();
            //cycle through inner nodes
            foreach (XmlNode kvp in service.SelectNodes("kvp"))
            {
                inner.Add(kvp.Attributes["key"].Value, kvp.Attributes["value"].Value);
            }
            outer.Add(service.Attributes["name"].Value, inner);
        }
        return outer;
    }
