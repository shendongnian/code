    public static List<ProductBuilder> PopulateProductBuilders(...)
    {
        // Logic to populate the collection
    }
    public static List<ProductBuilder> GetProductBuilders(GetProductsRequest productsRequest)
    {
        var productBuilders = PopulateProductBuilders();
        if(!productBuilders.Any())
        {
            Logger.LogMessage(productsRequest.SessionId, "No ProductBuilders were created.");
            throw new ProductException(ProductException.ExceptionCode.SaveFailed, "No Service has qualified.");
        }
    }
