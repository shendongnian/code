    [HttpPost]
    public ActionResult Create(YourModel model)
    {
       if(ModelState.IsValid)
       {
          // Put your logic here
       }
    
       return View(create)
    }
