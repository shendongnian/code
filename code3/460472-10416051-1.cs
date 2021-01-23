    public ActionResult Index()
    {
        IList<Test> tests = GetTests().ToList();
        return View(tests);
    }
