    public ActionResult Edit(int id)
    {
         var movie = this.connection.MovieContext.SingleOrDefault(m => m.ID == id);
         var vm = new MovieCreateViewModel{ Id = movie.Id};
         return View(vm);
    }
    //
    // POST: /Movie/Edit/5
    [HttpPost]
    public ActionResult Edit(MovieCreateViewModel vm)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var movie = new Movie{Id = vm.Id};
                this.connection.MovieContext.Attach(movie);
                this.connection.MovieContext.Context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        catch
        {
            return View(movieedit);
        }
    }
