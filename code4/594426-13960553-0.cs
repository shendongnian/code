    public ActionResult Index()
    {
        var list = _context.MyClass.Take(10);
        return View(list);
    }
