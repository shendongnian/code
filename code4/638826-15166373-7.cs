    public XElement ToXml()
    {
        return new XElement("Employee",
                   new XText(Name),
                   Subordinates.Select(s => s.ToXml()));
    }
