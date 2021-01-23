        [HttpGet]
        public ActionResult SearchIndex(string searchString)
        {
            var movies = db.Movies.Select(x => x);
            if (!string.IsNullOrEmpty(searchString))
                movies = movies.Where(x => x.Title.Contains(searchString));
            return View(movies);
        }
        [HttpPost]
        public ActionResult SearchIndex(string searchString, string someOtherParam)
        {
            var movies = db.Movies.Select(x => x);
            if (!string.IsNullOrEmpty(searchString))
                movies = movies.Where(x => x.Title.Contains(searchString));
            //do something different than your get...
            return View(movies);
        }
