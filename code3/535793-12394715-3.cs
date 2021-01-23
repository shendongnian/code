    [HttpPost]
    public ActionResult Create(CompanyViewModel model)
    {
      if(ModelState.IsValid)
      {
          //check for model.SelectedCountry property value here
          //Save and Redirect
      }
      //Reload countries here
      return View(model);
    }
