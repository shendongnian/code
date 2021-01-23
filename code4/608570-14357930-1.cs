     doc.Descendants("Key")
        .Select(key => new Key()
        {
            name = (string)key.Attribute("name"),
            IsNew = (bool)key.Attribute("new"),
            v = key.Elements()
                    .Select(value => new Value()
                    {
                        name = (string)value.Attribute("name"),
                        type = (string)value.Attribute("type"),
                        patchedValue = (string)value.Attribute("patchedValue")
                    }).ToArray()
        }).ToArray();
