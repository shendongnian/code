    [HttpPost]
    public ActionResult aSaveNews(NavigationViewModel model)
    {
     if(ModelState.IsValid)
     {
        //Now you will have the Value inside the model Properties
        string name=model.Name;
        string url=model.URL;
        bool isEnabled=model.IsEnabled;
    
        //now save to your Data base and Redirect (PRG pattern)
    
     }
     return View(model);
    }
