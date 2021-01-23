    public class TestController : Controller
    {
		IUserManager _userManager;
		public TestController(IUserManager userManager)
		{
			_userManager = userManager;
		}
        //
        // GET: /Test/
        public ActionResult Index()
        {
            return View();
        }
    }
