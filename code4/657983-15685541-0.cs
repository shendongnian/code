    Dictionary<int, Part> partsById = doc.Root
        .Element("Parts")
        .Elements("Part")
        .Select(p => new Parts
                {
                    Id = (int) p.Attribute("id"),
                    Name = (string) p.Attribute("name"),
                    Active = (bool) p.Attribute("active")
                })
        .ToDictionary(part => part.Id);
