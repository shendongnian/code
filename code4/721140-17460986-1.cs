    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            return null;
        }
        
        [RequiresParameter("id")]
        public ActionResult Index(int id)
        {
            return null;
        }
    }
