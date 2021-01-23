    [HttpPost]
    public ActionResult Create(int parentId, MyCreateViewModel viewModel)
    {
        //Process the viewModel, map to EF models and persist to the database
    
        return RedirectToAction(viewModel.ViewToRender);
    }
