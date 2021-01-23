    xmlSkuDescDoc.Descendants("Context")
                    .Where(el => el.Attribute("enabled").Value == "1")
                    .Elements()
                    .ToList()
                    .ForEach(i => newContextElementCollection.Add(new ContextElements { Property = i.Name.ToString(), Value = i.Value }));
