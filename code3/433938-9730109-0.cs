    [HttpPost]
    public ActionResult Create(Search search)
    {
      search.Created = DateTime.Now;
    
      search. SearchSet = "test data";
      search. URLParameter  = 1432567389;
    
    TryUpdateModel(search);
    
    if (ModelState.IsValid)
      {
         _db.Searchs.Add(search);
        _db.SaveChanges();
        return RedirectToAction("Index");
    
      }
    
     return View(search); 
    }
