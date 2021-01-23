    [HttpPost]
    public ActionResult Create(Comment c)
        {
            Blog blog = db.Blogs.Single(b => b.BlogID == c.BlogID);
            blog.Comments.Add(c);
            db.SaveChanges();
            return RedirectToAction("Details", "Blog", new { ID = c.BlogID });
        }
