    public class OtherOneController : Controller
    {
        public ActionResult RandomAction()
        {
            return RedirectToAction("Index", "Main");
        }
    }
