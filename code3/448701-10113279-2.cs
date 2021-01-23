        public ViewResult Index()
        {
            var posts = db.Posts.Include(p => p.Blog).Include(p => p.Comments);
            return View(posts.ToList());
        }
