	public void NewsAsync(string city)
    {
        AsyncManager.OutstandingOperations.Increment();
        NewsService newsService = new NewsService();
        newsService.GetHeadlinesCompleted += (sender, args) =>
        {
            AsyncManager.Parameters["headlines"] = args.Result;
            AsyncManager.OutstandingOperations.Decrement();
        };
        newsService.GetHeadlinesAsync(city);
    }
    public ActionResult NewsCompleted(object headlines)
    {
        return View("News", new ViewStringModel
        {
            NewsHeadlines = (string[])headlines
        });
    }
