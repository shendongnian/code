    public ActionResult Index()
    {
        List<Product> model = GetProductList();
        View(model);
    }
