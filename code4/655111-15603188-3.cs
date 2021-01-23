    [HttpPost]
    public ActionResult Edit(Post post)
    {
        if (ModelState.IsValid) {
            var dbPost = db.Posts.FirstOrDefault(p => p.Id == post.Id);
            if (dbPost == null)
            {
                return HttpNotFound();
            }
            dbPost.Author = post.Author;
            dbPost.Message = post.Message;
            dbPost.Headline = post.Headline;
            db.SaveChanges();
    
            return RedirectToAction("Index", "Home");
        }
    
        return View(post);
    }
    [HttpPost]
    public ActionResult Add(Post post)
    {
        if (ModelState.IsValid) {
            var dbPost = db.Create<Post>();
            dbPost.Author = post.Author;
            dbPost.Message = post.Message;
            dbPost.Headline = post.Headline;
            dbPost.Date = DateTime.Now(); // Don't trust client to send current date
            db.SaveChanges();
    
            return RedirectToAction("Index", "Home");
        }
    
        return View(post);
    }
