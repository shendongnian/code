    ProductSold product = new ProductsSold();
    product.ItemNo = myReader.GetString(0);
    product.ItemSize = myReader.GetString(1);
    product.ItemPrice = myReader.GetDecimal(2);
    product.UnitsSold = myReader.GetInt32(3);
    context.ProductsSolds.InsertOnSubmit(product);
