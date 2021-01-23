    public ActionResult Index()
    {
        Connect connection = new Connect();
        var movies = connection.Connection().OrderBy(m => m.Title);
        return View(movies);
    }
