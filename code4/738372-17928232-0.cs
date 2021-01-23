    public class OtherOne : Controller
    {
        public ActionResult RandomAction()
        {
            return RedirectToAction("Index", "Main");
        }
    }
