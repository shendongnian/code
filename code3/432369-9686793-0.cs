    if(ModelState.IsValid)
    {
        aktualisierteZielgruppe.Bezug = _db.Bezug.Find(aktualisierteZielgruppe.Bezug.Id);
        // The problem is here.  EF doesn't mark associations as modified
        // the same way it tracks scalar types.
        _db.Entry(aktualisierteZielgruppe).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
