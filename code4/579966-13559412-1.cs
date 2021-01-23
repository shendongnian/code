     [HttpGet]
     public ActionResult Index()
     {
          var attributes = Attribute.GetCustomAttributes(typeof(HomeController).GetMember("Index").First());
          return View();
     }
