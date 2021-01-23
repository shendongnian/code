    public static string ActiveDirectory(string xmlPath, string applicationGUID, string Element)
    {
        XDocument dbConfig = XDocument.Load(xmlPath);
    
        var ret = (dbConfig
                         .Descendants("Zone")
                         .Where(a =>
                         {
                             XElement ag =
                                 a.Element("ApplicationGUID");
    
                             return ag != null &&
                                    (ag.Value == applicationGUID);
                         })
                         .SingleOrDefault());
        if(ret == null)
           ret = (dbConfig
                         .Descendants("Zone")
                         .Where(a =>
                         {
                             XElement ag =
                                 a.Element("ApplicationGUID");
    
                             return ag != null &&
                                    (ag.Value == "3773e594efga42688cd5113cf316d4d3");
                         })
                         .SingleOrDefault());
        if(ret != null)
        {
               XElement cs = ret.Element(Element);
    
               return cs == null ? null : cs.Value;
        }
        return null;
    }
