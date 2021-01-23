    public static string GetXml<T>(T obj)
    {
        Type t = typeof(T);
        XElement xElem = new XElement("ENTITY");
        xElem.Add(t.Name,
                  new XElement("ATTRIBUTES",
                               t.GetFields()
                                .Select(f => new XElement("ATTRIBUTE", 
                                                          new XAttribute("name",f.Name), 
                                                          f.GetValue(obj)))
                                .ToArray())
        );
        return xElem.ToString();
    }
