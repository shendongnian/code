    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            MovieTable dbMovies = new MovieTable();
            dbMovies.All();
            return View(dbMovies);
        }
        ...
    }
