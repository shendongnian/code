    public ActionResult Index()
    {
        string username = Environment.UserName // or however you get it
        User user = new User{UserName = username};
        return View(user);
    }
