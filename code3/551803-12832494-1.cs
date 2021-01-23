	public ActionResult Index()
	{   
		var movies = new List<Movie>();
		// populate the data
		
		return View(movies);
	}
