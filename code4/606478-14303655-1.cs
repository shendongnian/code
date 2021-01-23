    [HttpPost]
    public ActionResult Index(Step1ViewModel postedModel)
    {
        if (!ModelState.IsValid)
        {
            // validation for this step failed => redisplay the view so that the 
            // user can fix his errors
            return View(postedModel);
        }
        // validation passed => fetch the model from the session and update the corresponding
        // property
        var originalModel = Session["model"] as ModelClass;
        originalModel.Prop1 = postedModel.Prop1;
        
        return RedirectToAction("Step2");
    }
