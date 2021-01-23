    public ActionResult AddComment(Comment comment, int id)
    {
        if (ModelState.IsValid)
        {
            // NEW
            comment.Moderated = false;
            comment.PostId = id;
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Blog", new { id = id });
        }
        return RedirectToAction("Details", "Blog", new { id = id });
    }
