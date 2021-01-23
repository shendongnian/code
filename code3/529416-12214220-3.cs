    public static IQueryable<Category> GetCategories(string catName, XDocument xml)
    {
          var cats = from c in xml.Descendants("category")
                     let categoryName = c.Attribute("name").Value
                     let descendants = c.Descendants()
                     where (catName == "" || categoryName == catName)
                     select new Category
                     {
                          Name = categoryName,
                          Items = from d in descendants
                                  let typeId = d.Attribute("id").Value
                                  select new Item
                                  {
                                      Id = typeId,
                                      Name = d.Value,
                                      Category = GetCategories(categoryName, xml).FirstOrDefault()
                                  }
                    };
    
           return cats.AsQueryable();
    }
