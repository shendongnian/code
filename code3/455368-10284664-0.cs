    routes.MapRoute("MyLang", "{lang}",
         new { controller = "Home", action = "Home",  }
    class HomeController{
      public ActionResult Home(string lang)
      {
        return View();
      }
    }
