    public ProductController(IProductBuilder productBuilder)
    {
      _productBuilder = productBuilder;
    }
    public ActionResult ProductList(SomeType SomeParamIfYouNeed)
    {
      var model = _productBuilder.Get(SomeParamIfYouNeed);
    
      return PartialView("ProductList", model);
    }
