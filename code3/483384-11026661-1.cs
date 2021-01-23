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
    if (productQuery.GetType() == typeof(IQueryable<ProductIn>)) {
        ((IQueryable<ProductIn>)productQuery).( ... and away you go with Linq ...);
    }
