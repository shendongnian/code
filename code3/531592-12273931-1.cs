    [HttpPost]
    public ActionResult Create(HttpPostedFileBase file) {
                
      if (file.ContentLength > 0) {
        string name = Path.GetFileName(file.FileName);
        // HINT: Im uploading to App data folder!
        string path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
        file.SaveAs(path);
      }
      return RedirectToAction("Index");
    }
