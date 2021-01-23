    public ActionResult Index()
    {
        var posts = (from p in db.Set<BlogPost>()
                     select new PostViewModel
                     {
                         Title = p.Title,
                         DateCreated = p.DateCreated,
                         Content = p.Content,
                         Topics = p.Topics,
                         Comments = p.Comments,
                         CommentCount = p.Comments.Count
                     }).ToList();
        IEnumerable<Topic> topics = ... go ahead and fetch the topics you want to show in the ddl
        var blog = new BlogViewModel
        {
            Posts = posts,
            Topics = topics.Select(t => new SelectListItem
            {
                Value = t.ID,
                Text = t.TopicText
            })
        };
        return View(blog);
    }
