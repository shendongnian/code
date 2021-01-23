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
