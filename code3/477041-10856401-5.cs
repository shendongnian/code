    [HttpPost]
    public ActionResult Create(VideoUploadModel VM, HttpPostedFileBase videoUpload)
    {
        if (ModelState.IsValid)
        {
            if(videoUpload != null) { // save the file
                var serverPath = server.MapPath("~/files/" + newName);
                videoUpload.SaveAs(serverPath);
            }
            db.SaveChanges();
            return RedirectToAction("Index");  
        }
        ViewBag.UserId = new SelectList(db.DBUsers, "Id", "FName", VM.videoModel.UserId);
        return View(VM);
    }
