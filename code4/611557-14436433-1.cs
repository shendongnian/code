        public ActionResult Index()
        {
            var posts = db.Posts.Include(a => a.Comments);
            return View(posts.ToList());
        }
