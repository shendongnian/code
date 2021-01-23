    [HttpPost]
    public ActionResult Register(RegisterModel model)
    {
       string msg = db.Register(model) 
       TempData["Message"] = "You are registered!";
       return RedirectToAction("Index", "Dashboard");
    }
