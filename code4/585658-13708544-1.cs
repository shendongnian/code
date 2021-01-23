    [HttpPost]
    public ActionResult Create(IEnumerable<album> album)
    {
        if (ModelState.IsValid) 
        {
           // persist and redirect... whatever
        }
        return View(album);
    }
