        [HttpPost]
        public ActionResult CreateComment(FormCollection values, int id)
        {
            var comment = new Comment();
            TryUpdateModel(comment);
    
            /** ADD THIS LINE **/
            Post post = db.Posts.Find(id);
    
            if (ModelState.IsValid)
            {
                var context = new UsersContext();
                var username = User.Identity.Name;
                var user = context.UserProfiles.SingleOrDefault(u => u.UserName == username);
                var userid = user.UserId;
    
                comment.UserId = userid;
                comment.Date = DateTime.Now;
    
                /***  ADD THIS TWO LINES ***/
                comment.Post = post;
                comment.PostId = post.PostId;
    
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Create", "Post");
            }            
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "Content", comment.PostId);
            return View(comment);
        }
