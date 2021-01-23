    // main action that returns a view
    public ViewResult Index()
    {
       var model = ...
       return View(model);
    }
    
    // couple of child actions each returns a partial view
    // which will be called from the index view
    [ChildActionOnly]
    public PartialViewResult ChildAction1()
    {
      var model = ...
      return PartialView(model);
    }
    
    [ChildActionOnly]
    public PartialViewResult ChildAction2()
    {
      var model = ...
      return PartialView(model);
    }
    
    // index view
    Index.cshtml
    @model ...
    
    @Html.Action("ChildAction1");
    @Html.Action("ChildAction2");
    
    ...
