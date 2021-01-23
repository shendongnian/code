    public ActionResult Create()
    {
        ViewBag.List = new SelectList(PopulateDDLs(), "Id", "Name"); 
        return View();
    }
    [HttpPost]
    public ActionResult Create(Objinfo obj)
    {
        if (ModelState.IsValid)
        {
            m_ObjManager.CreateObj(obj);
            return RedirectToAction("SearchIndex");
        }
        ViewBag.List = new SelectList(PopulateDDLs(), "Id", "Name"); 
        return View(obj);
    }
