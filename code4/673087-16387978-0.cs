    [HttpPost]
    public ActionResult Create(Character character)
    {
        if (ModelState.IsValid)
        {
            character.user = db.UserProfiles.Find(u => u.UserID = WebSecurity.CurrentUserId); 
    
            db.Characters.Add(character);
            db.SaveChanges();
        ...
    }
