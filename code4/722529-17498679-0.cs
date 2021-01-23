    public ActionResult ListMovies()
    {
      MovieSummary summary = Deserialize();
      return View(summary);
    }
