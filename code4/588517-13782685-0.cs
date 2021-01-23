        public ActionResult Index()
        {
            ViewBag.ConnectionStrings = System.Configuration.ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>();
            ViewBag.AppSettings = System.Configuration.ConfigurationManager.AppSettings;
            return View();
        }
