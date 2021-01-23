    public List<Products> GetProducts()
    {
        XElement myElement = XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/products.xml"));
        var query = from a in myElement.Elements("Product")
                    select new Products
                    {
                        ProductName = a.Element("ProductName").Value,
                        Tag = a.Element("Tag").Value,
                        SupportPage = a.Element("SupportPage").Value,
                        ProductPage = a.Element("ProductPage").Value,
                        ProductCategories = (from b in a.Elements("ProductCategories")
                                            select new ProductCategories
                                            {
                                                ProductCategory = b.Element("ProductCategory").Value,
                                                //PartNumbers = GetPartNumbers(myElement.Elements("Product").Elements("ProductCategories").Elements("PartNumbers").Elements("PartNumber"))
                                                PartNumbers = (from c in b.Elements("PartNumbers")
                                                              select new PartNumbers
                                                              {
                                                                   PartNumber = c.Element("PartNumber").Value
                                                              }).ToList()
                                            }).ToList(),
                        Downloads = (from bb in a.Elements("Downloads").Elements("Download")
                                    select new Downloads
                                    {
                                        Comment = bb.Element("Comment").Value,
                                        Url = bb.Element("Url").Value,
                                        Version = bb.Element("Version").Value
                                    }).ToList(),
                    };
    
        return query.ToList();
    }
