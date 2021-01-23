    [HttpGet]
    public ActionResult Home() 
    {
      var model = new HomeModel { Greeatings = "Hi" };
      return View(model);
    }
