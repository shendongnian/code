    Person       Country
    -------      -------
    PersonID     CountryID
    FullName     Name
    CountryID
    
    
    public ActionResult Create(PersonModel model)
    {
        if (ModelState.IsValid)
        {
            DbEntities db = new DbEntities();
            Person person = new Person();
            person.FullName = model.FullName;
            person.CountryID = model.CountryID; // This value is from the DropDownList.
        
            db.AddToPersons(person);
            db.SaveChanges();
    
            return RedirectToAction("Index", "Home");       
        }
        
        // Something went wrong. Redisplay form.
        return View(model);
    }
