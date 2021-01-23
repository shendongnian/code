    XElement root = XElement.Load(file); // or .Parse(string)
    List<CustomClassName> list = root.Descendants("ClassName").Select(x =>
    new CustomClassName()
    {
        ClassName = x.Name.LocalName, // is the name, not the value    
        classAttributes = x.Parent.Element("ClassAttribute").Value, // Value is a string, not a list, you'll have to do the conversion.
        moreAttributes = x.Value // is the value, but Value is a string, not a list, you'll have to do the conversion.
    })
    .ToList();
