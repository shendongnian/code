    [HttpGet]
    public ActionResult Index(int somethingICareAbout)
    {
      return View(new IndexViewModel(somethingICareAbout));
    }
    
    [HttpPost]
    public ActionResult Index(IndexViewModel viewModel)
    {
      viewModel.SaveChanges()/DoWork()/Whatever();
      return View(new viewModel());
    }
