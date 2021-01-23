    [HttpPost] 
    public ActionResult Create(Trade trade) { 
    trade.Name=HttpContext.User.Identity.Name; //this is where the current user is added
    if (ModelState.IsValid) { 
    db.Movies.Add(trade); 
    db.SaveChanges(); 
    return RedirectToAction("Index"); 
    } 
    return View(trade); 
    } 
