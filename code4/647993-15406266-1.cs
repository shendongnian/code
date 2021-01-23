    from g in xdoc.Descendants("Group")
    where (int)g.Element("Id") == id // filtering groups here
    select new Group {
       Id = (int)g.Element("Id"),
       GroupName = (string)g.Element("GroupName"),
       PersonId = (int)g.Element("PersonId"),
       DateCreated = (DateTime)g.Element("DateCreated"),
       DateModified = (DateTime)g.Element("DateModified"),
       Products = g.Elements("Products")
                   .Select(p => new Product {                   
                       ProductId = (int)p.Attribute("ProductId"),
                       ProductName = (string)p.Element("ProductName"),
                       CategoryName = (string)p.Element("CategoryName"),
                       SubCategoryId = (int)p.Element("SubCategoryId"),
                       SubCategoryName = (string)p.Element("SubCategoryName")
                   }).ToList()
    }
