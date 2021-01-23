    public ActionResult DynamicReport
    {
        //Get your Model
        Model.model1 = model_01 = Model.DynamicGridDataSource.GetDynamicModel()
        //Get the name of what model is being returned so view knows which 
        //partial view to load
        ViewBag.Message = model_01.Name
        ...
        return View(model_01)
    }
