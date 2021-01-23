    [HttpGet]
    public ActionResult GetAllPeople(GenericViewModel<People> viewModel)
    {
        var query = (from x in db.People select x); // Select all people
        viewModel.Results = query.ToList();
        
        return View("_MyView", viewModel);
    }
