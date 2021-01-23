        [HttpPost]
        public ActionResult Reply(PostViewModel viewModel)
        {
            Post masterPost = db.Posts.FirstOrDefault(p => p.PostID == viewModel.ReplyTo);
            Post post = new Post();
            post.PostID = 0;
            post.CreatedOn = DateTime.Now;
            post.ModifiedOn = DateTime.Now;
            post.ReplyTo = masterPost;
            post.Forum = db.Forums.FirstOrDefault(f=>f.ForumID == masterPost.Forum.ForumID);
            post.User = (User)Session["User"];
            post.Title = viewModel.Title;
            post.Content = viewModel.Content;
    
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("View", "Posts", new { id = ReplyTo });
            }
            return View(post);
        }
