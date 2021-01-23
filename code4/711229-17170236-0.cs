    public ActionResult Edit(Movie movie)
    {
        if(movie == null)
        {
            // or what else you what...
            return View();
        }
        if (ModelState.IsValid)
        {
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(movie);
    }
