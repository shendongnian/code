    [HttpPost]
    public ActionResult Create(VideoUploadModel VM, HttpPostedFileBase vid)
    {
        //add your vid to the model or whatever you want to do with it :)
        if (ModelState.IsValid)
        {
            db.Videos.AddObject(VM.videoModel);
            db.SaveChanges();
            return RedirectToAction("Index");  
        }
        ViewBag.UserId = new SelectList(db.DBUsers, "Id", "FName", VM.videoModel.UserId);
        return View(VM);
    }
