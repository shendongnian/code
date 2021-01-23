    [HttpPost]
    public ActionResult Create(Lab lab)
    {
      ViewBag.DispPatientId = Lab.PatientId;
      try
      {
        lab.Active = true;
        db.Labs.Add(lab);
        db.SaveChanges();
        return RedirectToAction("Index", "Lab", new { patid = lab.PatientId });
      }
      catch
      {
        ViewBag.Phase = new SelectList(StatusList(), "Text", "Value");
        ViewBag.Name = new SelectList(db.LabOptions, "Test", "Value", lab.Name);
        return View(lab);
      }
    }
