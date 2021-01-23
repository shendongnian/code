    public ActionResult AddComment(int id)
    {
        if (ModelState.IsValid)
        {
            Comment comment = new Comment();
            TryUpdateModel(comment, new[] { "Email ", "DateCreated", "Content", "etc" });
            comment.PostId = id;
            db.Comments.Add(comment);
            ...
        }
        ...
    }
