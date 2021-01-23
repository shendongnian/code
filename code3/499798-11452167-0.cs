    public class MovieController : Controller
    {
      private Connect connection;
      private Movie movie;
      public MovieController() 
      {
           this.connection = new Connect();
           this.movie = new Movie();
      }
      [HttpPost]
      public ActionResult Create(Movie moviecreated)
      {
        try
        {
            // TODO: Add insert logic here
            this.connection.MovieContext.AddObject(moviecreated);
            this.connection.MovieContext.Context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch
        {
            return View(movie);
        }
       }
    }
    public class Connect
    {
        private ObjectSet<Movie> movieContext;
    
        public ObjectSet<Movie> MovieContext 
        {
            get
            {
                if (this.movieContext == null) 
                { 
                    this.SetMovieContext(); 
                }
    
                return this.movieContext;
            }
        }
    
        public void SetMovieContext() 
        { 
            var connStr = ConfigurationManager.ConnectionStrings["Entities"]; 
            var context = new ObjectContext(connStr.ConnectionString); 
            this.movieContext = context.CreateObjectSet<Movie>(); 
        } 
    }
