    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult HandleForm(MyModel myModel)
    {
        // Do whatever you need to here.
        return RedirectToAction("OtherAction", myModel);
    }
    public ActionResult OtherAction(MyModel myModel)
    {
        return View(myModel);    
    }
