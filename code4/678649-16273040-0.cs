    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Movie movie, HttpPostedFile fileUpload)
    {
        if (ModelState.IsValid)
        {
            db.MovieContext.Add(movie);
            db.SaveChanges();
            
            var postedFile = fileUpload;
            postedFile.SaveAs(Server.MapPath("~/UploadedFiles") + pelicula.Id);
            
            return RedirectToAction("Index");
        }
        return View(movie);
    }
