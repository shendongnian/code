    public static XElement ElementByNameAttribute(this XElement container,
                                                  string name)
    {
        return container.Elements("str")
                        .First(x = x.Attribute("name").Value == name);
    }
