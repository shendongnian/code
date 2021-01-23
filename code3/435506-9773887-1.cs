    public ActionResult Index()
    {
        return View();
    }
    [HttpGet] // This isn't required
    public ActionResult Edit(int id)
    {
       // load object and return in view
       ViewModel viewModel = Load(id);
       return View(viewModel);
    }
    [HttpPost]
    public ActionResult Edit(ViewModel viewModel)
    {
       // Attempt to save the posted object if it works, return index if not return the Edit view again
       bool success = Save(viewModel);
       if (success)
       {
           return RedirectToAction("Index");
       }
       else
       {
          ModelState.AddModelError("There was an error");
          return View(viewModel);
       }
    }
