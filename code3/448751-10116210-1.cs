    public ActionResult Index()
    {
       // assuming entity framework
       List<PostViewModel> posts = (from p in context.Set<Post>()
                                    select new PostViewModel {
                                       Title = p.Title,
                                       DateCreated = p.DateCreated,
                                       Topics = p.Topics
                                    }).ToList();
       return View(posts);
    }
