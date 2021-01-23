    CustomView.cshtml:
    if (ViewData.ContainsKey("PartialViewName")) {
    @Html.Partial(ViewData[PartialViewName]);
    }
    Controller.cs:
    public ActionResult Create(FormCollection form)
    {
        TryUpdateModel(model);
        ViewData[PartialViewName] = "CreateSuccess";
        if(!ModelState.IsValid) { return View(); }  // this works correctly
    
        var model = new Account();
    
        var results = database.CreateAccount(model);
    
        if(results) return View("CustomView", model); // trying to make this dynamic
    
        return View(model); // this works correctly
    }
