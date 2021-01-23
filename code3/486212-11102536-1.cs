    public ActionResult ActionTwo () 
    {
        // this doesn't work (of course)
        var model = new ActionTwoViewModel("blub");
    
        return View(model);
    }
