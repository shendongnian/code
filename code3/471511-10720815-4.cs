    [HttpPost]
    public ActionResult Edit(MyModel model) {
        if (ModelState.IsValid) {
        //save your items here
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        model.Genres = new SelectList(db.Genres, "GenreId", "Name", model.Album.GenreId);
        model.Artists = new SelectList(db.Artists, "ArtistId", "Name", model.Album.ArtistId);
        return View(album);
    }      
