    [HttpPost]
    public ActionResult Create(EventModel eventmodel, HttpPostedFileBase file)
    { 
       if (ModelState.IsValid)
       {
          var filename = Path.GetFileName(file.FileName);
          var path = Path.Combine(Server.MapPath("~/Uploads/Photo/"), filename);
          file.SaveAs(path);
          tyre.Url = filename;
    
          _db.EventModels.AddObject(eventmodel);
          _db.SaveChanges();
          return RedirectToAction("Index");
       }
       return View(eventmodel);
    }
