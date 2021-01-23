    [HttpPost]
    public ActionResult Edit(Post post)
    {
        if (ModelState.IsValid) {
            var dbPost = from p db.Posts where p.Id == post.Id;
            dbPost.Author = post.Author;
            dbPost.Message = post.Message;
            dbPost.Headline = post.Headline;
            db.SaveChanges();
    
            return RedirectToAction("Index", "Home");
        }
    
        return View(post);
    }
