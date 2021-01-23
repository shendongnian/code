    public class WebController : Controller
    {
        public ActionResult GetDate()
        {
           return Content(DateTime.Now.ToString());
        }
    }
