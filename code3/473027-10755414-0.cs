    public ActionResult Index(SearchForm formModel)
    {
        ModelState.Remove("CurrentViewDate");
        if(formModel.CurrentViewDate == null)            
        {
            formModel.CurrentViewDate = DateTime.Now.AddDays(1d);
        }
        else
        {
            formModel.CurrentViewDate = formModel.CurrentViewDate.AddDays(1d);
        }
        return View(model);
    }
