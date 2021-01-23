    [HttpPost]
    public ActionResult Edit(cpd_certificates cpd_certificates)
    {
        if (ModelState.IsValid)
        {
            db.Entry(cpd_certificates).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", new { id = cpd_certificates.id });
        }
        return View(cpd_certificates);
    }
