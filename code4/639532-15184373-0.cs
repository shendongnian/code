    [HttpPost]
    public ActionResult Edit(int id, TModel model, string returnUrl)
    {
        // Model is invalid; redisplay view
        if (!ModelState.IsValid) return View();
        // Record not found in DB; return 404
        var record = db.Entity.Find(id);
        if (record == null) return HttpNotFound();
        // Everything OK; update record and redirect back
        UpdateModel(record);
        db.SaveChanges();
        return Redirect(returnUrl);
    }
