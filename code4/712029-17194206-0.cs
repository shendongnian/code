    [HttpGet]
    public ActionResult SearchIndex(string searchString)
        {
            var movies = db.Movies.Select(x => x);
            if (!string.IsNullOrEmpty(searchString))
                movies = movies.Where(x => x.Title.Contains(searchString));
            return View(movies);
        }
