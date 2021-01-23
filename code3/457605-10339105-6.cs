    public ActionResult Index()
    {
        // The model could be of any form and come from anywhere but
        // the important thing is that at the end of the day you will have
        // a list of titles here
        DomainModel[] items = ...
        // Now let's map this domain model into a view model 
        // that will be adapted to the requirements of our view.
        var viewModel = Mapper.Map<IEnumerable<DomainModel>, IEnumerable<MyViewModel>>(items);
        return View(viewModel);
    }
