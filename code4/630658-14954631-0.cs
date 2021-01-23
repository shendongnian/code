    public List<T> parseXmlToCustomObject<T> (string xml, String root, String key)
        where T : ISetupable, new()
    {
            XDocument doc = XDocument.Parse(xml);
            List<T> result = 
                (
                    from x in doc.Element(root).Elements(key)
                    select new T().Setup(x)
                    ).ToList();
            return result;
    }
