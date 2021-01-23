    public class HomeController : Controller
    {
    ...
        public JsonResult GetTicks()
        {
            return Json(DateTime.Now.Ticks, JsonRequestBehavior.AllowGet);
        }
    }
