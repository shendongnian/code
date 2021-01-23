    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection)
    {
        // Get the original record to edit from the database.
        var gruppe = _db.Zielgruppe.Include("Bezug").Single(z => z.Id == id);
        // This will attempt to do the model binding and map all the submitted 
        // properties to the attached entity.
        if (TryUpdateModel(grupppe))
        {
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
