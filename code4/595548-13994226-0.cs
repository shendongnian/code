        [HttpPost]
        public ActionResult CreateComment(FormCollection values)
        {
            var comment = new Comment();
            TryUpdateModel(comment);
    
            if (ModelState.IsValid)
            {
                var context = new UsersContext();
                var username = User.Identity.Name;
                var user = context.UserProfiles.SingleOrDefault(u => u.UserName == username);
                var userid = user.UserId;
    
                comment.UserId = userid;
                comment.Date = DateTime.Now;
                //here
                comment.PostId = values["postId"];
    
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Create", "Post");
            }
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "Content", comment.PostId);
            return View(comment);
        }
