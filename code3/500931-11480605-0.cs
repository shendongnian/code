    [HttpPost]
    public ActionResult EditTablo(Tablo tablo, int? RessamId, HttpPostedFileBase image)
    { 
        if (ModelState.IsValid)
        {
            container.Tablo.Attach(tablo);
            container.ObjectStateManager
                .ChangeObjectState(tablo, System.Data.EntityState.Modified);
            if (RessamId != null)
            {
                tablo.Ressam = (from table in container.Ressam
                                where table.RessamId == RessamId
                                select table).Single();
                
                TryUpdateModel(tablo.Ressam);
            }
            container.SaveChanges();
        }
        return View(tablo);
    }
