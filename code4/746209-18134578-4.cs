    MyController: Controller 
    {
      public ActionResult GetPartialViewAction()
      {
        return PartialView("mypartialview", new partialViewModel());
      }
    }
