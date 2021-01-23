    [HttpGet]
    public ActionResult Get([FromUri]ViewModel model)
    {
        // Do stuff
        return View("ViewName", model);
    }
