    MyController: Controller 
    {
      public ActionResult GetPartialViewAction()
      {
        return View("mypartialview", new partialViewModel());
      }
    }
