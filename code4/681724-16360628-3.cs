    public FeedController : Controller
    {
       public ActionResult Index()
       {
            var data = DAL.GetFeed();
            var model = Mapper.Map<Feed, FeedViewModel>(data);
            model.EditMode = true;
            return View(model)
        } 
     }
