    [HttpGet]
    public ActionResult MyView()
    {
       var model = //get your model.
       
       int count = context.Trades.Where(t => t.name == model.name).Count();
       
       ViewBag.Count = count;
    
       return View(model);
    
    }
