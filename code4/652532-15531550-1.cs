    public ActionResult Submit(string method)
    {
      return Redirect("Submit"+method);
    }
    
    public ActionResult SubmitCrash()
    {
      return View();
    }
    
    public ActionResult SubmitBug()
    {
      return View();
    }
