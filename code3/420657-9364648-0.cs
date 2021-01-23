    public ActionResult Index(int id)
    {
        ProductInfo product = repository.GetProductInfo(id);
        ProductViewModel viewModel = Mapper.Map<ProductInfo, ProductViewModel>(product);
        return View(viewModel);
    }
