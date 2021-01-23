    private IEnumerable<Category> GetCategories(string parent)
    {
        var cats = from c in xml.Descendants(parent)
               let categoryName = c.Attribute("name").Value
               let descendants = c.Descendants()
               select new Category
               {
                    Name = categoryName,
                    Items = from d in descendants
                            let typeId = d.Attribute("id").Value
                            select new Item
                            {
                                Id = typeId,
                                Name = d.Value,
                                Category = GetCategories(d.Value).FirstOrDefault()
                            }
               };
    }
