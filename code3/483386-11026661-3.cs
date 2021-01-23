    object productQuery;
    if (test == true)
    {
        productQuery = ordersRepository.ProductIn; //it returns IQueryable<ProductIn> type
    }
    else
    {
        productQuery = ordersRepository.ProductOut; //it returns IQueryable<ProductOut> type
    }
    // ... more logic ...
    var unboxed = productQuery as IQueryable<ProductIn>;
    if (unboxed != null) {
        unboxed.Where( ... and away you go with Linq ...);
    }
