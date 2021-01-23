    public ActionResult Submit(string action)
    {
      return Redirect("Submit"+action);
    }
    
    public ActionResult SubmitCrash()
    {
      return View();
    }
    
    public ActionResult SubmitBug()
    {
      return View();
    }
