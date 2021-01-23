        [Authorize]//Place this on each action or controller class so that can can get User's information
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var db = new EfDb();                
                try
                {                   
                    var userProfile = db.UserProfiles.Local.SingleOrDefault(u => u.UserName == User.Identity.Name)
                                    ?? db.UserProfiles.SingleOrDefault(u => u.UserName == User.Identity.Name);
                    if (userProfile != null)
                    {
                        var note= new Note
                                            {
                                               UserProfile = userProfile,
                                               Description = model.Description 
                                            };                        
                        db.Notes.Add(note);
                        db.SaveChanges();
                        return RedirectToAction("About", "Home");
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    throw;
                }
            }            
            return View(model);
        }
