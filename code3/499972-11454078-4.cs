    var productRows = from p in ListProducts
                      join row in Ds1Products.TblProduct
                      on p.Name equals row.Name 
                      select new { NewPrice = p.Price, Row = row };
    foreach (var productInfo in productRows)
    {
        productInfo.Row.Price = productInfo.NewPrice;
    }
    Adapter.Update(Ds1Products, "TblProducts"); 
