    public ActionResult Create(BlogDetailsViewModel viewModel)
    {
        Blog blog = db.Blogs.Single(b => b.BlogID == viewModel.Comment.BlogID);
        Comment c = viewModel.Comment;
        blog.Comments.Add(c);
        db.SaveChanges();
        return RedirectToAction("Details", "Blog", new { ID = c.BlogID });
    }
