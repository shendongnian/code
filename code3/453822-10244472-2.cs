    public ViewResult Index(int categoryId, int locationId)
    {
        HomeFormViewModel model = new HomeFormViewModel();
        model.Suppliers = service.Suppliers(model.CategoryId, model.LocationId);
        return View(model);
    }
