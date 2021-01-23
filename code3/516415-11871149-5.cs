    public ActionResult Index()
    {
        ContentViewModel viewModel = new ContentViewModel();
        viewModel.Users = db.Users.ToList();
        return View(viewModel);
    }
