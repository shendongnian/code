        var categories = x.Root.Elements().Select(e =>
            new Category
            {
                Id = int.Parse(e.Attribute("id").Value),
                Name = e.Attribute("name").Value,
                Description = e.Attribute("description").Value,
                SubCategories = e.Elements().Select(e1 =>
                    new Category
                    {
                        Id = int.Parse(e1.Attribute("id").Value),
                        Name = e1.Attribute("name").Value,
                        Description = e1.Attribute("description").Value
                    }).ToList()
            }).ToList();
