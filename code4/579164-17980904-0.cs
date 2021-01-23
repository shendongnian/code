    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Guid id, FormCollection collection)
    {
        var user = db.Users.Find(id);
        if (user != null)
            TryUpdateModel(user);
        else
            return HttpNotFound();
        if (ModelState.IsValid)
        {
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(user);
    }
