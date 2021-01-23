    public class HomeController : Controller
    {
        mapEntities _db = new mapEntities();
        public ActionResult Index()
        {
            return View(_db.river.ToList());
        }
    }
