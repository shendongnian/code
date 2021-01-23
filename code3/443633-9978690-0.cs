    [HttpGet]
    public ActionResult Index()
    {
        return View(TempData["email"] ?? string.Empty);
    }
    [HttpPost]
    public ActionResult Index(string email)
    {
        TempData["email"] = email;
        return RedirectToAction("Index");
    }
