    var productRows = from p in ListProducts
                      join row in Ds1Products.Tables["TblProducts"].AsEnumerable()
                      on p.Name equals row.Field<String>("Name")
                      select new { NewName = p.Name, Row = row };
    foreach(var productInfo in productRows)
    {
        productInfo.Row.SetField<String>("Name", productInfo.NewName);
    }
    Adapter.Update(Ds1Products, "TblProducts"); 
