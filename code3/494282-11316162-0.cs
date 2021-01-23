    [HttpGet] // Actions are GET by default, so can omit this
    public ActionResult YourAction(int id)
    {
        // GET
    }
    
    [HttpPost]
    public ActionResult YourAction(YourModel model)
    {
        // POST
    }
