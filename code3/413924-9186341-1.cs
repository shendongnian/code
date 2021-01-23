    public class HomeController : BaseController
    {
        private readonly IArticleService _articleService;
    
        public HomeController(IArticleService articleService, IUserService userService) : base(userService)
        {
            _articleService = articleService;
        }
    
        public ActionResult Index()
        {
            // do stuff with services
            return View()
        }
    }
