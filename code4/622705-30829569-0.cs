    public ActionResult Index(string username, string password, string rememberMe)
    {
       if (!string.IsNullOrEmpty(username))
       {
          bool remember = bool.Parse(rememberMe);
          //...
       }
       return View();
    }
