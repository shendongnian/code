    public ActionResult List()
    {
      ViewBag.Data = repos.GetData();
    
      return View();
    }
