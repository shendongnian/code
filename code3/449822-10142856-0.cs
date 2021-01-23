    [HttpPost]
    public ActionResult DoSomething(ViewModel model)
    {
       if(ModelState.IsValid)
       {
           // Logic Here
       }
       return View(model)
    }
