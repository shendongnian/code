    public class SearchController : Controller
    {
        //
        // GET: /Search/
    
        public ActionResult Index()
        {
            return View();
        }
    
        public ActionResult SearchUser(string UserId)
        {
            User user = ... go and fetch the user given the user id from wherever your users are stored (a database or something)
            return View(user);
        }
    }
