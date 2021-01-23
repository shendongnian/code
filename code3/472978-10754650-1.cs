    var doc = XElement.Load("path to the file");
    var results = doc.Descendants("category")
        .Select(cat => new
        {
            Id = cat.Attribute("id").Value,
            Name = cat.Descendants("name").First().Value,
            Subcategories = cat.Descendants("subcat")
                .Select(subcat => new
                {
                    Id = subcat.Attribute("id").Value,
                    Name = subcat.Descendants("name").First().Value
                })
         })
         .GroupBy(x=>x.Id)
         .Select(g=>new
         {
             Id = g.Key,
             Name = g.First().Name,
             Subcategories = g.SelectMany(x=>x.Subcategories).Distinct()
         });
