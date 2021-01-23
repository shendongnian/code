    public ActionResult AddComment(Comment comment, int id)
    {
        if (ModelState.IsValid)
        {
            CommentService.Save(comment);
            return RedirectToAction("Details", "Blog", new { id = id });
        }
        return RedirectToAction("Details", "Blog", new { id = id });
    }
