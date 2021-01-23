    public ActionResult Index(TableViewModel model)
    {
       var data = _productRepository.AsQueryable().TableHelper(model);
    
       ... //Operation on data
    }
