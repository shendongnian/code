    [HttpGet]
    public ActionResult YourActionName()
    {
        // replace this with however you're getting your language variable
        var languages = new CollectionOfSomeSort();
    	var model = new LanguageFormModel()
    	{
            SelectedLanguage = "fr-ca",
    		Languages = new SelectList(languages, "Code", "Name", model.SelectedLanguage)
    	};
    
    	return View(model);
    }
