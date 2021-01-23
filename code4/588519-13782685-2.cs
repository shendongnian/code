    public ActionResult Index()
    {
      ViewBag.ConnectionStrings =
        ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>();
      ViewBag.AppSettings = ConfigurationManager.AppSettings;
      return View();
    }
