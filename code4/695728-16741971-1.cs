    public sealed class HomeViewModel{
        public MovieListViewModel TopTenByRating { get; set; }
        public MovieListViewModel TopTenByDate { get; set; }
    }
    public ActionResult Index()
    {
        var model = new HomeViewModel();
        model.TopTenByDate =
            _db.Movies
                .OrderByDescending(m => m.DateEntered)
                .Take(10)
                .Select(m => new MovieListViewModel 
                {
                    Id = m.Id,
                    Title = m.Title,
                    Genre = m.Genre,
                    ReleaseDate =  m.ReleaseDate,
                    CountOfReviews = m.Reviews.Count()
                });
        model.TopTenByRating = // something else
        return View(model);
    }
