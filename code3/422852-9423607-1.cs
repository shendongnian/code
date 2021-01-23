    public ActionResult Index()
    {
        ViewBag.Message = "Welcome to ASP.NET MVC!";
        var longRunningTask = Task.Factory.StartNew( DoLengthyOperation );
        Session["MyApp_SessionTask"] = longRunningTask;
        return View();
    }
    
    public ActionResult About()
    {
        // Note that the below Wait method has a bunch of overloads you can use
        // i.e. only wait up until a fixed timeout, wait until a separate cancellation
        // token is signaled, etc.
        var longRunningTask = (Task) Session["MyApp_SessionTask"];
        if ( longRunningTask != null )
            longRunningTask.Wait();
        return View();
    }
