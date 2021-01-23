    public ActionResult Dialog()
    {
        var model = new MyViewModel();
        return PartialView(model);
    }
    [HttpPost]
    public ActionResult Dialog(MyViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // the model is invalid => redisplay the partial
            return PartialView(model);
        }
        // TODO: at this stage the model is valid 
        // => pass it to the service layer for processing
 
        // everything went fine => set the ShouldReload flag to true
        // so that the view refreshes its opener and closes itself
        model.ShouldReload = true;
        return PartialView(model);
    }
