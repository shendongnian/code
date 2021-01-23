    [HttpPost]
    public ActionResult Edit(Album album, int id)
    {
        if (ModelState.IsValid)
        {
            album.AlbumId = id;
            db.Entry(album).State = EntityState.Modified;
