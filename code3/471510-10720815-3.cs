    public ActionResult Edit(int id) 
    {
        var model = new MyModel();
        model.Album = db.Albums.Find(id);
        model.Artist = yourArtist; //whatever you want it to be
        model.Genres = new SelectList(db.Genres, "GenreId", "Name", model.Album.GenreId);
        model.Artists = new SelectList(db.Artists, "ArtistId", "Name", model.Album.ArtistId);
        return View(model);
    }  
