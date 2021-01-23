    var productRows = from p in ListProducts
                      join row in Ds1Products.Tables["TblProducts"].AsEnumerable()
                      on p.Name equals row.Field<String>("Name")
                      select new { NewPrice = p.Price, Row = row };
    foreach(var productInfo in productRows)
    {
        productInfo.Row.SetField<Double>("Price", productInfo.NewPrice);
    }
