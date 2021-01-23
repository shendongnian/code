    [HttpPost]
    public ActionResult Create(VideoUploadModel VM, IEnumerable<HttpPostedFileBase> videoUpload)
    {
        if (ModelState.IsValid)
        {
            if(videoUpload != null) { // save the file
                foreach(var file in videoUpload) {
                   var serverPath = server.MapPath("~/files/" + file.Name);
                    videoUpload.SaveAs(serverPath);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");  
        }
        ViewBag.UserId = new SelectList(db.DBUsers, "Id", "FName", VM.videoModel.UserId);
        return View(VM);
    }
