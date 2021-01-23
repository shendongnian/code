    public static XElement ElementByNameAttribute(this XContainer container,
                                                  string name)
    {
        return container.Elements("str")
                        .First(x => x.Attribute("name").Value == name);
    }
