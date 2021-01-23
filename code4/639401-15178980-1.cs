    decimal? minPrice = null;
    decimal? maxPrice = null;
    var skuParameter = new MySqlParameter("?SKU", productToUpload.Sku);
    var basePrices = db.Database.SqlQuery<PriceOutput>("call GetSkuPrices(?SKU)",                                                       
                                                       skuParameter).FirstOrDefault();
    if (basePrices != null)
    {
        minPrice = basePrices.MinPrice;
        maxPrice = basePrices.MinPrice;
    }
