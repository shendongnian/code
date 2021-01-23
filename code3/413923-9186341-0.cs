    public class HomeController : BaseController
    {
        private readonly IArticleService _articleService;
    
        public HomeController(IUserService userService, IArticleService articleService)
         : base(userService)
        {
            _articleService = articleService;
        }
    
        public ActionResult Index()
        {
            // do stuff with services
            return View()
        }
    }
