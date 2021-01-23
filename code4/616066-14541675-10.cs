    var categories = (from category in element.Descendants("category")
                        orderby int.Parse( category.Attribute("id").Value )
                        select new Category()
                        {
                            Id = int.Parse(category.Attribute("id").Value),
                            ParentId = category.Attribute("parentId") == null ?
                                null as int? : int.Parse(category.Attribute("parentId").Value),
                            Children = new List<Category>()
                        }).Distinct().ToList();
    
