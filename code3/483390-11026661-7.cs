    IQueryable<IProduct> productQuery;
    if (test == true)
    {
        productQuery = ordersRepository.ProductIn; //it returns IQueryable<ProductIn> type
    }
    else
    {
        productQuery = ordersRepository.ProductOut; //it returns IQueryable<ProductOut> type
    }
    string myResult = productQuery.Where(item => item.productNo == productNo).FirstOrDefault(); 
