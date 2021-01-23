    [HttpPost]
    public ActionResult Create(Character character)
    {
        if (ModelState.IsValid)
        {
            character.user = db.UserProfiles.Find(u => u.UserID = (int) Session["UserID"]); 
            db.Characters.Add(character);
            db.SaveChanges();
        ...
    }
