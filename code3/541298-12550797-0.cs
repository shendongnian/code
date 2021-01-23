    [HttpPost]
    public ActionResult AddProperty(AddPropertyViewModel viewModel)
    {
     [...]
     
     viewModel.CustomerTypes = websiterepository.GetCustomerTypeSelectList();
     return View(viewModel);
    }
