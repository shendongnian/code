    public ActionResult Index()
    {
        var viewModel = new TestViewModel();
        return View(viewModel);
    }
    [HttpPost]
    public ActionResult Index(TestViewModel viewModel)
    {
        string youChose = viewModel.SelectedItemValue;
        // ...
    }
