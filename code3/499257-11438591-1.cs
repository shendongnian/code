    public ActionResult Create()
    {
      var model=new UserProfile();
      model.SexTypes = new[]
      {
         new SelectListItem { Value = "M", Text = "Male" },
         new SelectListItem { Value = "F", Text = "FeMale" },         
      }; 
      return View(model);
    }
