    public class BaseController : Controller
    {
        public ActionResult Root()
        {
            return RedirectToAction("Home","MyApp");
        }
    }
