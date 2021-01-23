    public ActionResult Index()
    {   
    	var movies = new List<Movie>();
    
    	var songsPath = Server.MapPath("~/Content/themes/base/songs");
    	var folders = Directory.GetDirectories(songsPath);
    
    	foreach (var folder in folders)
    	{
    		Movie movie = new Movie();
    		movie.MovieName = new DirectoryInfo(folder).Name
    
    		string[] files = Directory.GetFiles(folder);
    
    		foreach (var file in files)
    		{
    			if (Path.GetExtension(file) == ".jpg" ||
    				Path.GetExtension(file) == ".png")
    			{
    				movie.Images.Add(Path.Combine(songsPath, file));
    			}
    			else 
    			{
    				movie.Songs.Add(Path.Combine(songsPath, file));
    			}
    		}
    
    		movies.add(movie);
    	}
    	return View(movies);
    }
