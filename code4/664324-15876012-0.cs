    public ActionResult SomeAction()
    {
     using( var db = new ApplicationEntities() )
     {
      //todo: use db
     }
     return View();
    }
