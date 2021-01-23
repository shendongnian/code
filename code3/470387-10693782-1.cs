    [HttpPost]
    public ActionResult Create(YourModelTypeHere model)
    {
        return RedirectToAction("Add", new { tekst = model.tekst });
    }
    public ActionResult Add(string tekst) 
    {
        ViewBag.test = tekst;
        return View();
    }
