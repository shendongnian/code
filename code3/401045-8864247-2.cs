    [HttpPost]
    public ActionResult Create(IEnumerable<HttpPostedFileBase> files)
    {
        try
        {
            if (ModelState.IsValid)
            {
                //Persist the files uploaded.
            }
            return RedirectToAction("Index");
        }
        catch
        {
            return View(model);
        }
    }
