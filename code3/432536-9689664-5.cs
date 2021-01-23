    [HttpPost]
    public ActionResult Create(ProductModel model, IEnumerable<HttpPostedFileBase> files)
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
