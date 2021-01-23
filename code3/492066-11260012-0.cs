    public ActionResult Create(Comment c)
    {
        Blog blog = db.Blogs.Single(b => b.BlogID == c.BlogID);
        blog.Comments.Add(c);
        // associate the comment with the blog that you have retrieved
        c.Blog = blog;
        db.SaveChanges();
        return RedirectToAction("Details", "Blog", new { ID = c.BlogID });
    }
