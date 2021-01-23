      [GET("Resources")]
      public ActionResult Index()
      {
          return View();
      }
      [POST("Resources")]
      public ActionResult Create()
      {
          return RedirectToAction("Index");
      }
