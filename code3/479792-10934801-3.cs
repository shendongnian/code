    public ActionResult Search()
    {
        var viewModel = new SearchViewModel()
        {
            viewModel.LocationSelection = _repository.All<Location>()
        };
    
        // any other logic here or in service class
        return View(viewModel);
    }
