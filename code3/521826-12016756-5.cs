    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var badge = new Badge
            {
                ID = 1,
                Name = "badge"
            };
            var user = new User
            {
                Badge = badge
            };
            badge.Users = new[] { user }.ToList(); 
            return Json(badge, JsonRequestBehavior.AllowGet);
        }
    }
