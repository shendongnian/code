    public ActionResult Index()
    {
        photoBlogModelDataContext _db = new photoBlogModelDataContext();
        var posts = _db.Posts.OrderByDescending(x => x.DateTime).Take(4).ToArray();
        var galleries = _db.Galleries.OrderByDescending(x => x.ID).Take(4).ToArray();
        return View(Tuple.Create(galleries, posts));
    }
