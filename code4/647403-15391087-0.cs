                                           from o in a.Products
                                           select new XElement("Products",
                                           new XAttribute("ProductId", o.Id),
                                            new XElement("ProductName", o.ProductName),
                                            new XElement("CategoryId", o.Category.Id),
                                            new XElement("CategoryName", o.Category.CategoryName),
                                            new XElement("SubCategoryId", o.SubCategory.Id),
                                            new XElement("SubCategoryName", o.SubCategory.SubCategoryName),
