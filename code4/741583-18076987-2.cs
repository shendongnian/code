        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection values)
        {
            var jogger = new Jogger();
            TryUpdateModel(jogger);
            var context = new TestContext();
            var userqq = User.Identity.Name;
            var user = context.UserProfiles.SingleOrDefault(u => u.UserName == userqq);
            if (ModelState.IsValid)
            {
                
                    jogger.JoggerId = user.UserId;
                    jogger.Pronation = values["Pronation"];
                    db.Joggers.Add(jogger);
                    db.SaveChanges();
                   return View();
              
               
            }
                ViewBag.JoggerId = new SelectList(db.UserProfiles, "UserId", "UserName", jogger.JoggerId);
                return View(jogger);
            
        }
