    public ActionResult Create(GameTBL gametbl)
        {
            if (ModelState.IsValid)
            {
                //First you get the gamer, from GamerTBLs
                var gamer = db.GamerTBLs.Where(k => k.UserName == User.Identity.Name).SingleOrDefault();
                //Then you add the game to the games collection from gamers
                gamer.GameTBLs.Add(gametbl);
                db.SaveChanges(); 
                return RedirectToAction("Index");               
            }
            return View(gametbl);
        }
