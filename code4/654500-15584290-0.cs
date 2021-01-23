    [HttpPost]
        public ActionResult Create(Player model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new EfDb())
                {
                    var userProfile = db.UserProfiles.Single(u => u.UserName == User.Identity.Name);
                    if (userProfile != null)
                    {
                        var player = new Player
                                         {
                                             UserProfile = userProfile,                                             
                                             ....
                                             ....                                              
                                         };  
                        player.TeamId = 5;                      
                        db.Players.Add(player);                          
    
                        db.SaveChanges();
                    }
                }
            }
            PopulateTeamsDropDownList(model.TeamId);
            return View(model);
        }
