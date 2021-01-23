    [Route("api/products")]
    public IEnumerable<Product> GetAllProducts(){}
    
    [Route("api/products/sold")]
    public IEnumerable<Product> GetSoldProducts(){}
