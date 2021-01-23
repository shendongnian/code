    [HttpPost, ValidateInput(false)]
    public ActionResult Edit(Post post, int[] tagIds)
    {
        if (ModelState.IsValid)
        {            
            post.Tags = db.Tags.Where(tag => tagIds.Contains(tag.Id));
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // some code here
    }
