    Type type = obj.GetType();
    if (set.Contains(obj))
        return new XElement("Class", new XAttribute("name", type.Name));
    set.Add(obj);
    return new XElement("Class", ...);
