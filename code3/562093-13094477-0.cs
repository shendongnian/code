    [HttpPost]
        public ActionResult Create(InspectionInfo inspectioninfo)
        {
                if (ModelState.IsValid)
            {
                db.InspectionInfos.Add(inspectioninfo);
                db.Contact.Attach(inspectioninfo.Contact);
                db.County.Attach(inspectioninfo.County);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
    
            return View(inspectioninfo);
        }
