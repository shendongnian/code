    List<ProductItem> yourProductlist = new List<ProductItem>();
    yourProductlist.Add(new ProductItem() { ProductName = "A", UnitPrice = 50 });
    yourProductlist.Add(new ProductItem() { ProductName = "B", UnitPrice = 150 });
    List<SalesItem> yourSaleslist = yourProductlist.Select(x => 
                               new SalesItem() { ProductName = x.ProductName, 
                                                 UnitPrice = x.UnitPrice }).ToList();
