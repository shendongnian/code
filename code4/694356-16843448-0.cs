    // note - just a string (name) passed in
    public XElement Get(string name)
    {
        XElement xelement = XElement.Load("Settings.xml");
        IEnumerable<XElement> settings = xelement.Elements();
        return settings.FirstOrDefault(x => x.Name == name);
    }
