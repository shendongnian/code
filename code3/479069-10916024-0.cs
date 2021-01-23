    public ViewResult Index()
    {
       var model = ...
       return View(model);
    }
    
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
    
    Index.cshtml
    @model ...
    
    @Html.Action("ChildAction1");
    @Html.Action("ChildAction2");
    
    ...
