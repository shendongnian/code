        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PUser model)//You should use a ViewModel here
        {
            if (ModelState.IsValid)
            {
                var db = new EfDb(); // If you introduce abstration to you Context, you could avoid this.               
                var player = new Player
                                 {   
                                     Name = model.Name,                                             
                                     UserContact= new UserContact
                                                        {
                                                           Phone = model.UserContact.Phone             
                                                        }
                                  };
                        
                 db.PUser.Add(user);
                 db.SaveChanges();
                 return RedirectToAction("Index", "Home");
             }                        
            return View(model);
        }
