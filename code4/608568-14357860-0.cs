            .Select(e =>
                new Key
                {
                    name = (string)e.Attribute("name"),
                   IsNew =Convert.ToBoolean((string)e.Attribute("new")),
                    v = e.
                    Elements("Value").Select(i =>
                        new Value
                        {
                            name = (string)i.Attribute("name"),
                            type = (string)i.Attribute("type"),
                            patchedValue = (string)i.Attribute("patchedValue")
                        }).ToArray()
                }).ToArray();
