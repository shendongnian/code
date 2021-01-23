    [HttpPost]
        public ActionResult Create(Player model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new EfDb())
                {
                    //Since you have the username cached, you can check the local EF cache for the object before hitting the db.
                    //var userProfile = db.UserProfiles.Single(u => u.UserName == User.Identity.Name);
                    var userProfile = db.UserProfiles.Local.SingleOrDefault(u => u.UserName == User.Identity.Name) 
                                   ?? db.UserProfiles.SingleOrDefault(u => u.UserName == User.Identity.Name);
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
