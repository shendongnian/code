    [HttpGet]
    public ActionResult Index()
    {
        var viewModel = new MyViewModel();
        viewModel.Members = FinanceDBContext.MemberInfoes.ToList();
        return View(viewModel);
    }
    [HttpPost]
    public ActionResult Index(MyViewModel viewModel)
    {
        string debug = string.Format("You selected member: {0}", viewModel.SelectedMemberId);
        return View(viewModel);
    }
