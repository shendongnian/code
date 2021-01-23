    public ProductBuilder(IProductService productService)
    {
      _productService = productService;
    }
    public List<Product> Get ()
    {
      // Rather than returning the _productService method call, you could do some mapping between what is returned and the model your view needs.
      return _productService.GetProducts();
    }
