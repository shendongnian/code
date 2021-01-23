    public ActionResult Index()
    {
        // do something when there's no id
    }
    
    [RequiresRouteValues("id")]
    public ActionResult Index(int id)
    {
        // do something when id is present
    }
