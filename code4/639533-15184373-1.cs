    [HttpPost]
    public ActionResult Edit(int id, TModel model, string returnUrl)
    {
        // Invalid model; redisplay view
        if (!ModelState.IsValid) return View();
        var entity = db.Entity.Find(id);
        
        // Entity not found; return 404
        if (entity == null) return HttpNotFound();
        // Everything OK; update entity and redirect back
        UpdateModel(entity);
        db.SaveChanges();
        return Redirect(returnUrl);
    }
