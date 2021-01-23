    public ActionResult Review(MyModel mm) 
    {
        if (ModelState.IsValid)
        {
            return View(mm);
        } else return RedirectToAction("Create");
    }
