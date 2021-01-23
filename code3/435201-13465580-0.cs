    [HttpGet]
    public ActionResult Index(int viewId)
    {
        return View(new IndexViewModel(viewId));
    }
    [HttpPost]
    public ActionResult Index(IndexViewModel model)
    {
        model.DoSomethingUsefulWithPostData();
        return View(model);
    }
