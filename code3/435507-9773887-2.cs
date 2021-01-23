    public ActionResult Index()
    {
        return View();
    }
    [HttpGet] // This isn't required
    public ActionResult Edit(int id)
    {
       // load object and return in view
       ViewModel viewModel = Load(id);
       // get the previous url and store it with view model
       viewModel.PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
       return View(viewModel);
    }
    [HttpPost]
    public ActionResult Edit(ViewModel viewModel)
    {
       // Attempt to save the posted object if it works, return index if not return the Edit view again
       bool success = Save(viewModel);
       if (success)
       {
           return RedirectToAction(viewModel.PreviousUrl);
       }
       else
       {
          ModelState.AddModelError("There was an error");
          return View(viewModel);
       }
    }
