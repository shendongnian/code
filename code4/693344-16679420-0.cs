    public ActionResult Index(string whichStyle)
    {
        MyStyleViewModel model = new MyStyleViewModel();
        // -- (Load relevant style settings here) --
        Response.ContentType = "text/css";
        return View(model);
    }
