    public static Device FromXElement(XElement element)
    {
        return new Device
        {
            ID = (int) element.Attribute("Number"),
            Name = (string) element.Attribute("Name"),
            Functions = element.Element("Functions").Elements("Function")
                             .Select(Function.FromXElement)
                             .ToList();
        };
    }
