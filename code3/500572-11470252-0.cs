    public ActionResult Foo(int id)
    {
        // the controller queries the repository to retrieve a domain model
        Bar domainModel = Repository.Get(id);
        // The controller converts the domain model to a view model
        // In this example I use AutoMapper, so the controller actually delegates
        // this mapping to AutoMapper but if you don't have a separate mapping layer
        // you could do the mapping here as well.
        BarViewModel viewModel = Mapper.Map<Bar, BarViewModel>(domainModel);
        // The controller passes a view model to the view
        return View(viewModel);
    }
