    public static string ActiveDirectory(string xmlPath, string applicationGUID,string Element)
    {
    XDocument dbConfig = XDocument.Load(xmlPath);
    return (dbConfig
                     .Descendants("Zone")
                     .Where(a =>
                     {
                         XElement ag =
                             a.Element("ApplicationGUID");
                         return ag != null &&
                                (ag.Value == applicationGUID || ag.Value == "3773e594efga42688cd5113cf316d4d3");
                     })
                     .OrderBy(a => a.Element("ApplicationGUID").Value == "3773e594efga42688cd5113cf316d4d3" ? 1 : 0)
                     .Select(
                         a =>
                         {
                             XElement cs =
                                 a.Element(Element);
                             return cs == null
                                        ? null
                                        : cs.Value;
                         })
                     .FirstOrDefault());
    }
