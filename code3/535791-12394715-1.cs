    public ActionResult Create()
    {
       CompanyViewModel vm=new CompanyViewModel();
       // The below line is hard coded for demo. you may replace 
       //  this with loading data from your Data access layer/ Existing array
       vm.Countries= new[]
       {
          new SelectListItem { Value = "1", Text = "United States" },
          new SelectListItem { Value = "2", Text = "Canada" },
          new SelectListItem { Value = "3", Text = "Australia" }
       };
       return View(vm);
    }
