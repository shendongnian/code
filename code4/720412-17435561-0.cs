    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit()
    {
        Bill bill = new Bill();
        if (TryUpdateModel(bill))
        {
            db.Entry(bill).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(bill);
    }
