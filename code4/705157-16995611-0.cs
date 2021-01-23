    [HttpPost]
    public ActionResult Create(UserDetail userdetail)
    {
        if (ModelState.IsValid)
        {
            db.UserDetails.Add(userdetail);
            db.SaveChanges();
            return RedirectToAction("SearchCust");  
        }
    
        userdetail.ProjectDetail = db1.ProjectDetails.ToList();
    
        return View(userdetail);
    }
