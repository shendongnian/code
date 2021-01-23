    public ActionResult Index()
    {
        ContentViewModel viewModel = new ContentView();
        viewModel.Users = db.Users.ToList();
        return View(viewModel);
    }
