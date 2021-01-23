    [AutoMapTo(typeof(ProductViewModel))]
    public ActionResult Index(int id)
    {
        ProductInfo product = repository.GetProductInfo(id);
        return View(product);
    }
