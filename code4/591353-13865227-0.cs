       [HttpPost]
        public ActionResult Create(FormCollection values)
        {
            var post = new Post();
            TryUpdateModel(post);
            if(ModelState.IsValid)
            {
                var context = new UsersContext();
                var username = User.Identity.Name;
                var user = context.UserProfiles.SingleOrDefault(u => u.UserName == username);
                var userid = user.UserId;
                // var firstname = user.FirstName;
                post.UserId = userid;
                post.Date = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View("Create", post);
        }
