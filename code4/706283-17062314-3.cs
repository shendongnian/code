    public ProductController(IProductBuilder productBuilder)
    {
      _productBuilder = productBuilder;
    }
    public ActionResult ProductList()
    {
      var model = _productBuilder.Get();
    
      return PartialView("ProductList", model);
    }
