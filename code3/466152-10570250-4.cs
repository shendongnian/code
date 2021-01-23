    [HttpPost]
    public ActionResult Index(OnePersonAllInfoViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // the model is invalid => we must redisplay the same view =>
            // ensure that the PrefContactTypes property is populated
            model.PrefContactTypes = dbEntities
                .PreferredContactTypes
                .OrderBy(pct => pct.PreferredContactTypeID)
                .ToList();
            return View(model); 
        }
    
        // the model is valid => use the model.PreferredContactTypeID to do some
        // processing and redirect
        ...
        // Obviously if you need to stay on the same view then you must ensure that 
        // you have populated the PrefContactTypes property of your view model because
        // the view requires it in order to successfully render the dropdown list.
        // In this case you could simply move the code that populates this property
        // outside of the if statement that tests the validity of the model
        return RedirectToAction("Success"); 
    }
