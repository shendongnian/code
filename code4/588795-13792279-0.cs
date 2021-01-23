    public ViewResult Index(string id)
    {
        var posts = db.Posts.Where(p => p.Blog.Id == id);
        return View(posts.ToList());
    }
