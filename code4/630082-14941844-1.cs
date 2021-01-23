    public ActionResult Index()
    {
        var viewModel = new MessageViewModel {Message = "Hello from far away"};
        return View(viewModel);
    }
