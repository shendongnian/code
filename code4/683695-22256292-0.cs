    [HttpPost]
    [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase[] files)
        {
            // try to save the file
            foreach (HttpPostedFileBase file in files)
            {
                string picture = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/App_Data"), picture);
                string[] paths = path.Split('.');
                string time = DateTime.UtcNow.ToString();
                time = time.Replace(" ", "-");
                time = time.Replace(":", "-"); 
                file.SaveAs(paths[0] + "-" + time + ".jpg");
            }
    
            // try to save the new file name to db now.
            try
            {
                db.ImageUploads.Add(paths[0] + time + ".jpg");
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                 ..........
            }
    
            ViewBag.Message = "File(s) uploaded successfully";
            return RedirectToAction("Index");
        }
